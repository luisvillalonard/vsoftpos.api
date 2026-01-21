using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Seguridad;
using Pos.Core.Entidades.Seguridad;
using Pos.Core.Enumerables;
using Pos.Core.Interfaces;
using Pos.Core.Interfaces.Seguridad;
using Pos.Core.Modelos;
using Pos.Infraestructure.Atributos;
using Pos.Infraestructure.Extensiones;

namespace Pos.Api.Controllers.Seguridad
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepositorio _repositorio;
        private readonly IMailService _mailService;

        public UsuariosController(
            IMapper mapper,
            IUsuarioRepositorio repositorio,
            IMailService mailService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestFilter req)
        {
            var filters = ExpressionBuilder.New<Usuario>();
            if (req != null && !string.IsNullOrEmpty(req.Filter))
            {
                string filter = req.Filter.Trim();
                filters = usu => usu.Acceso.Contains(filter)
                    || usu.Empresa.Nombre.Contains(filter)
                    || usu.Rol.Nombre.Contains(filter)
                    || usu.Empleado!.Nombre.Contains(filter);
            }

            var result = await _repositorio.FindAndPagingAsync(
                req ?? new(),
                filters,
                user => user.OrderBy(ord => ord.Acceso),
                user => user.Rol, user => user.Empresa, user => user.Empleado!
            );
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<UsuarioDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDto modelo)
        {
            var item = _mapper.Map<Usuario>(modelo);
            var result = await _repositorio.PostAsync(item);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UsuarioDto modelo)
        {
            var result = await _repositorio.FindAsync(user => user.Id == modelo.Id);
            if (!result.Ok)
                return Ok(result);

            var usuario = _mapper.Map<IEnumerable<Usuario>>(result.Datos).FirstOrDefault();
            if (usuario == null)
                return Ok(new ResponseResult(false, "Código de usuario no encontrado"));

            usuario.EmpleadoId = modelo.Empleado?.Id;
            usuario.RolId = modelo.Rol.Id;
            usuario.EmpresaId = modelo.Empresa.Id;
            usuario.Correo = modelo.Correo;
            usuario.Cambio = modelo.Cambio;
            usuario.Activo = modelo.Activo;

            result = await _repositorio.PutAsync(usuario);
            return Ok(result);
        }

        [HttpPost("cambioClave")]
        public async Task<IActionResult> PostCambiarClave([FromBody] UsuarioCambioClaveDto modelo)
        {
            var result = await _repositorio.PostCambiarClaveAsync(modelo);
            return Ok(result);
        }
    }
}
