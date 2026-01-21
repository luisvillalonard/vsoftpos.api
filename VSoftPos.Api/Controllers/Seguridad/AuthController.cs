using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Pos.Core.Attributos;
using Pos.Core.Dto;
using Pos.Core.Dto.Seguridad;
using Pos.Core.Entidades.Seguridad;
using Pos.Core.Enumerables;
using Pos.Core.Interfaces;
using Pos.Core.Interfaces.Seguridad;
using Pos.Core.Modelos;
using Pos.Infraestructure.Helpers;
using Pos.Infraestructure.Repositorios.Seguridad;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pos.Api.Controllers.Seguridad
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepositorio _repositorio;

        public AuthController(
            IMapper mapper,
            IUsuarioRepositorio repositorio,
            IMailService mailService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        [AllowAnonymous]
        [HttpPost("validar")]
        public async Task<IActionResult> ValidarUsuario([FromBody] LoginDto modelo)
        {
            var result = await _repositorio.ValidarAsync(modelo);
            return Ok(result);
        }

        [HttpGet("menu")]
        public async Task<IActionResult> GetMenuASync()
        {
            IEnumerable<MenuDto> menu = [];

            // Busco el usuario
            var result = await ValidateUser();
            if (!result.Ok)
                return Ok(result);

            var usuario = (Usuario)result.Datos!;

            menu = GetAllMenus();
            if (!menu.Any())
                return Ok(new ResponseResult() { Ok = false, Datos = Enumerable.Empty<MenuDto>() }); ;

            var ids = usuario.Rol.Permiso.Select(opt => opt.MenuId).Distinct();
            foreach (var padre in menu)
            {
                padre.Items = padre.Items is null 
                    ? [] 
                    : padre.Items.Where(opt => ids.Any(id => id == (int)opt.Id))
                        .ToArray();
            }

            return Ok(new ResponseResult(menu));
        }

        [HttpGet("menu/todos")]
        public async Task<IActionResult> GetAllMenusASync()
        {
            // Busco el usuario
            var result = await ValidateUser();
            if (!result.Ok)
                return Ok(result);

            var todos = GetAllMenus();
            return await Task.FromResult(Ok(new ResponseResult(todos)));
        }

        private IEnumerable<MenuDto> GetAllMenus()
        {
            IEnumerable<Menu> allEnums = (Enum.GetValues(typeof(Menu))
                .Cast<Menu>());

            IEnumerable<MenuDto> allMenus = (Enum.GetValues(typeof(Menu))
                .Cast<Menu>()
                .Select(item => 
                {
                    var attr = item.GetMenuAttribute();
                    if (attr is null) return null;

                    return new MenuDto()
                    {
                        Id = (int)item,
                        Titulo = attr.Titulo,
                        EndPoint = attr.EndPoint,
                        Padre = (int)attr.Padre
                    };
                })
                .Where(item => item is not null)
                .AsEnumerable() ?? [])!;

            IEnumerable<MenuDto> padres = allMenus.Where(item => item.Padre == (int)Menu.Ninguno).ToArray();

            foreach (var padre in padres)
                padre.Items = allMenus.Where(opt => opt.Padre == padre.Id).ToArray();

            return padres;
        }

        private async Task<ResponseResult> ValidateUser()
        {
            // Obtengo el token del usuario
            var token = Request.Headers[nameof(HeaderDto.Authorization)].FirstOrDefault();
            if (token is null)
                return new(false, "Token de usuario inválido.");

            // Desencripto el token
            string codigo = Encoding.UTF8.GetString(Convert.FromBase64String(token));

            // Busco el usuario
            var result = await _repositorio.FindAsync(
                opt => opt.Codigo.ToLower().Equals(codigo.ToLower()),
                opt => opt.Rol, opt => opt.Rol.Permiso
            );
            if (!result.Ok)
                return result;

            else if (result.Datos is null)
                return new(false, "No fue posible obtener los datos del usuario.");

            var usuario = ((IEnumerable<Usuario>)result.Datos).FirstOrDefault();
            if (usuario is null)
                return new(false, "Token de usuario no encontrado.");

            return new(usuario);
        }
    }
}
