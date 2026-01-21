using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Configuraciones;
using Pos.Core.Entidades.Configuraciones;
using Pos.Core.Interfaces.Configuraciones;
using Pos.Core.Modelos;

namespace Pos.Api.Controllers.Configs
{
    [Route("[controller]")]
    [ApiController]
    public class CondicionesPagoController : ControllerBase
    {
        private readonly ICondicionPagoRepositorio _repositorio;
        private readonly IMapper _mapper;
        public CondicionesPagoController(IMapper mapper, ICondicionPagoRepositorio repositorio)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.GetAllAsync(cond => cond.OrderBy(ord => ord.Descripcion));
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<CondicionPagoDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CondicionPagoDto modelo)
        {
            var condicionPago = _mapper.Map<CondicionPago>(modelo);
            var result = await _repositorio.PostAsync(condicionPago);
            if (result.Ok)
                result.Datos = _mapper.Map<CondicionPagoDto>(result.Datos);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CondicionPagoDto modelo)
        {
            var condicionPago = _mapper.Map<CondicionPago>(modelo);
            var result = await _repositorio.PutAsync(condicionPago);
            if (result.Ok)
                result.Datos = _mapper.Map<CondicionPagoDto>(result.Datos);

            return Ok(result);
        }
    }
}
