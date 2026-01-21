using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Configuraciones;
using Pos.Core.Entidades.Configuraciones;
using Pos.Core.Interfaces.Configuraciones;

namespace Pos.Api.Controllers.Configs
{
    [Route("[controller]")]
    [ApiController]
    public class GruposController : ControllerBase
    {
        private readonly IGrupoRepositorio _repositorio;
        private readonly IMapper _mapper;
        public GruposController(IMapper mapper, IGrupoRepositorio repositorio)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.GetAllAsync(grupo => grupo.OrderBy(ord => ord.Nombre));
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<GrupoDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GrupoDto modelo)
        {
            var grupo = _mapper.Map<Grupo>(modelo);
            var result = await _repositorio.PostAsync(grupo);
            if (result.Ok)
                result.Datos = _mapper.Map<GrupoDto>(result.Datos);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] GrupoDto modelo)
        {
            var grupo = _mapper.Map<Grupo>(modelo);
            var result = await _repositorio.PutAsync(grupo);
            if (result.Ok)
                result.Datos = _mapper.Map<GrupoDto>(result.Datos);

            return Ok(result);
        }
    }
}
