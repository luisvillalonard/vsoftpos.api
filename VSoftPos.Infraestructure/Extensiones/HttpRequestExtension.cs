using AutoMapper;
using Microsoft.AspNetCore.Http;
using Pos.Core.Dto;
using Pos.Core.Dto.Seguridad;
using Pos.Core.Entidades.Seguridad;
using Pos.Core.Interfaces.Seguridad;
using Pos.Core.Modelos;

namespace Pos.Infraestructure.Extensiones
{
    public static class HttpRequestExtension
    {
        public static async Task<string?> GetUserCode(this HttpRequest request)
        {
            return await Task.FromResult(string.Empty);
            //if (request == null) return null;

            //var token = request.Headers
            //    .FirstOrDefault(x => x.Key == nameof(HeaderDto.Authorization)).Value
            //    .FirstOrDefault();

            //if (token is null)
            //    return null;

            //byte[] salt = Utileria.GetSalt(Encriptador.key);
            //var userCode = Encriptador.Decrypt(token, salt);

            //if (userCode is null)
            //    return null;

            //return await Task.FromResult(userCode);
        }
        
        public static async Task<UserApp?> GetUser(this HttpRequest request)
        {
            var userCode = await GetUserCode(request);
            if (userCode is null)
                return null;

            var userRepositorio = request.HttpContext.RequestServices.GetService(typeof(IUsuarioRepositorio)) as IUsuarioRepositorio;
            if (userRepositorio is null)
                return null;

            var result = await userRepositorio.FindAsync(
                user => user.Codigo.Equals(userCode),
                user => user.Empleado!, user => user.Empresa, user => user.Rol
            );
            if (!result.Ok)
                return null;

            var user = (result.Datos as IEnumerable<Usuario>)?.FirstOrDefault();
            if (user == null)
                return null;

            // Establezco el usuario a retornar
            UserApp? userApp = null;
            var mapper = request.HttpContext.RequestServices.GetService(typeof(IMapper));
            if (mapper is not null)
                userApp = ((IMapper)mapper).Map<UserApp>(user);

            return userApp;
        }
    }
}
