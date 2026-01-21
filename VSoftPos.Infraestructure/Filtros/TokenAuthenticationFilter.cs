using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Pos.Core.Dto;
using Pos.Core.Dto.Seguridad;
using Pos.Core.Entidades.Seguridad;
using Pos.Core.Interfaces.Seguridad;
using Pos.Core.Modelos;
using Pos.Infraestructure.Extensiones;
using System.Security.Claims;
using System.Text;

namespace Pos.Infraestructure.Filtros
{
    public class TokenAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            ControllerActionDescriptor? descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (descriptor is null)
            {
                context.Result = new UnauthorizedObjectResult(new ResponseResult(false, "No fue posible establecer la ruta solicitada."));
                return;
            }

            bool allowAnonymous = descriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            var headers = context.HttpContext.Request.Headers;
            if (headers is null)
                return;

            else if (!headers.ContainsKey(nameof(HeaderDto.Authorization)))
            {
                context.Result = new UnauthorizedObjectResult(new ResponseResult(false, "Token de autorización no encontrado."));
                return;
            }

            var token = headers[nameof(HeaderDto.Authorization)].FirstOrDefault();
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedObjectResult(new ResponseResult(false, "El token de autorización es inválido."));
                return;
            }

            token = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            if (token is null)
            {
                context.Result = new UnauthorizedObjectResult(new ResponseResult(false, "Token de autorización inválido."));
                return;
            }

            var userRepositorio = context.HttpContext.RequestServices.GetService(typeof(IUsuarioRepositorio)) as IUsuarioRepositorio;
            if (userRepositorio == null)
                return;

            var result = await userRepositorio.FindAsync(
                user => user.Codigo.ToLower().Equals(token.ToLower()), 
                user => user.Rol, user => user.Rol.Permiso);
            if (!result.Ok || result.Datos is null)
            {
                context.Result = new UnauthorizedObjectResult(new ResponseResult(false, "Token de usuario inválido."));
                return;
            }

            var user = ((IEnumerable<Usuario>)result.Datos).FirstOrDefault();
            if (user == null)
            {
                context.Result = new UnauthorizedObjectResult(new ResponseResult(false, "Token de usuario inválido."));
                return;
            }
        }
    }
}
