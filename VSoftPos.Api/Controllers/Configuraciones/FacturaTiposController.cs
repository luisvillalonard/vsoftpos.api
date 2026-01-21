using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Configuraciones;
using Pos.Core.Entidades.Configuraciones;
using Pos.Core.Interfaces.Configuraciones;

namespace Pos.Api.Controllers.Configs
{
    [ApiController]
    [Route("Facturas/Tipos")]
    public class FacturaTiposController : ControllerBase
    {
        private readonly IFacturaTipoRepositorio _repositorio;
        private readonly IMapper _mapper;
        public FacturaTiposController(IMapper mapper, IFacturaTipoRepositorio repositorio)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.GetAllAsync(tipo => tipo.OrderBy(ord => ord.Descripcion));
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<FacturaTipoDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FacturaTipoDto modelo)
        {
            var item = _mapper.Map<FacturaTipo>(modelo);
            var result = await _repositorio.PostAsync(item);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FacturaTipoDto modelo)
        {
            var item = _mapper.Map<FacturaTipo>(modelo);
            var result = await _repositorio.PutAsync(item);
            return Ok(result);
        }
    }
}
