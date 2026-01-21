using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Seguridad;
using Pos.Core.Entidades.Seguridad;
using Pos.Core.Interfaces.Seguridad;
using Pos.Core.Modelos;

namespace Pos.Api.Controllers.Seguridad
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRolRepositorio _repositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public RolesController(
            IMapper mapper,
            IRolRepositorio repositorio,
            IUsuarioRepositorio usuarioRepositorio)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _usuarioRepositorio = usuarioRepositorio ?? throw new ArgumentNullException(nameof(usuarioRepositorio));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.GetAllAsync(
                rol => rol.OrderBy(ord => ord.Nombre),
                rol => rol.Permiso);
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<RolDto>>(result.Datos);
            return Ok(result);
        }

        [HttpGet("{rolId}/porId")]
        public async Task<IActionResult> Get(int rolId)
        {
            var result = await _repositorio.FindAsync(
                item => item.Id == rolId,
                item => item.Permiso);
            if (!result.Ok)
                return Ok(result);

            var rol = _mapper.Map<IEnumerable<RolDto>>(result.Datos).FirstOrDefault();
            if (rol is null)
                return Ok(new ResponseResult(false, "Código de rol de usuario no encontrado"));

            return Ok(new ResponseResult(rol));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RolDto modelo)
        {
            var rol = _mapper.Map<Rol>(modelo);
            var result = await _repositorio.PostAsync(rol);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RolDto modelo)
        {
            var rol = _mapper.Map<Rol>(modelo);
            var result = await _repositorio.PutAsync(rol);
            return Ok(result);
        }
    }
}
