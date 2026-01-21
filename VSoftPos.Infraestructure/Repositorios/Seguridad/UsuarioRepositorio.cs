using AutoMapper;
using Pos.Core.Dto.Seguridad;
using Pos.Core.Entidades.Seguridad;
using Pos.Core.Interfaces.Seguridad;
using Pos.Core.Modelos;
using Pos.Infraestructure.Contexto;
using Pos.Infraestructure.Helpers;
using System.Security.Claims;
using System.Text;

namespace Pos.Infraestructure.Repositorios.Seguridad
{
    public class UsuarioRepositorio : RepositorioGenerico<Usuario, int>, IUsuarioRepositorio
    {
        internal readonly IMapper _mapper;
        internal readonly IPermisoRepositorio _repoPermiso;

        public UsuarioRepositorio(
            PosContext context,
            IMapper mapper,
            IPermisoRepositorio repoPermiso) : base(context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repoPermiso = repoPermiso ?? throw new ArgumentNullException(nameof(repoPermiso));
        }

        public override async Task<ResponseResult> PostAsync(Usuario entity)
        {
            string codigo = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
            byte[] key = Encoding.UTF8.GetBytes(codigo);
            byte[] iv = Encoding.UTF8.GetBytes(codigo.Substring(0, 16));

            string randomStr = Utileria.RandomString(20);
            byte[] clave = Encriptador.Encrypt(randomStr, key, iv);

            entity.Clave = Convert.ToBase64String(clave);
            entity.Codigo = codigo;
            entity.Salt = key;
            entity.Cambio = false;
            entity.Activo = false;

            var result = await base.PostAsync(entity);

            // Envio el correo
            //if (modelo.EnviarCorreo)
            //    _mailService.Correo_Nuevo_Usuario(usuario, newPass);

            return result;
        }

        public async Task<ResponseResult> ValidarAsync(LoginDto login)
        {
            var result = await base.FindAsync(
                    user => user.Acceso.ToLower().Equals(login.Acceso.ToLower()),
                    user => user.Rol);
            if (!result.Ok)
                return result;

            var usuario = result.Datos is null ? null : ((IEnumerable<Usuario>)result.Datos).FirstOrDefault();
            if (usuario == null)
                return new ResponseResult(false, "Nombre de usuario no encontrado");

            // Establezco el usuario a retornar
            UserApp userApp = _mapper.Map<UserApp>(usuario);

            // Valido que este activo y que ha cambiado la clave
            if (!userApp.Activo)
            {
                if (!userApp.Cambio)
                    return new ResponseResult(false, "Este usuario debe cambiar su clave, de lo contrario no podrá acceder al sistema.");
                else
                    return new ResponseResult(false, "Este usuario esta inactivo, contacte al administrador de su sistema.");
            }

            else if (!userApp.Cambio)
                return new ResponseResult(false, "Este usuario debe cambiar su clave, de lo contrario no podrá acceder al sistema.");

            else if (userApp.Rol is null)
                return new ResponseResult(false, "Este usuario no tiene un perfíl de usuarios asignado.");

            // Desencripto la clave
            byte[] key = usuario.Salt;
            byte[] iv = Encoding.UTF8.GetBytes(usuario.Codigo.Substring(0, 16));
            byte[] ciphertext = Convert.FromBase64String(usuario.Clave);
            string clave = Encriptador.Decrypt(ciphertext, key, iv);

            // Valido la clave del usuario
            if (!login.Clave.Equals(clave, StringComparison.OrdinalIgnoreCase))
                return new ResponseResult(false, "Clave de usuario incorrecta");

            // Agrego el token
            userApp.Token = Convert.ToBase64String(Encoding.UTF8.GetBytes(usuario.Codigo));

            // Retorno el usuario de la aplicacion
            return new ResponseResult()
            {
                Ok = true,
                Datos = userApp
            };
        }

        public async Task<ResponseResult> PostCambiarClaveAsync(UsuarioCambioClaveDto login)
        {
            if (string.IsNullOrEmpty(login.PasswordOld))
                return new ResponseResult("La clave anterior del usuario es inválida");
            
            else if (string.IsNullOrEmpty(login.PasswordNew))
                return new ResponseResult("La nueva clave del usuario es inválida");

            var result = await base.FindAsync(
                    user => user.Acceso.ToLower().Equals(login.Acceso.ToLower()),
                    user => user.Rol);
            if (!result.Ok)
                return result;

            var usuario = result.Datos is null ? null : ((IEnumerable<Usuario>)result.Datos).FirstOrDefault();
            if (usuario == null)
                return new ResponseResult("Código de usuario no encontrado");

            // Desencripto la clave
            byte[] key = usuario.Salt;
            byte[] iv = Encoding.UTF8.GetBytes(usuario.Codigo.Substring(0, 16));
            byte[] ciphertext = Convert.FromBase64String(usuario.Clave);
            string claveAnterior = Encriptador.Decrypt(ciphertext, key, iv);

            // Valido la clave del usuario
            if (!login.PasswordOld.Equals(claveAnterior, StringComparison.OrdinalIgnoreCase))
                return new ResponseResult(false, "La clave anterior es incorrecta");

            byte[] clave = Encriptador.Encrypt(login.PasswordNew, key, iv);

            usuario.Clave = Convert.ToBase64String(clave);
            usuario.Cambio = true;
            usuario.Activo = true;

            result = await base.PutAsync(usuario);
            if (!result.Ok)
                return result;

            // Retorno el token generado
            var userApp = _mapper.Map<UserApp>(usuario);

            // Agrego el token
            byte[] salt = Encriptador.NewKey();
            byte[] newToken = Encriptador.Encrypt(usuario.Codigo, key, iv);
            userApp.Token = Encoding.Unicode.GetString(newToken);

            // Retorno el usuario de la aplicacion
            return new ResponseResult()
            {
                Ok = true,
                Datos = userApp
            };
        }
    }
}
