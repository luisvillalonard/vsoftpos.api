using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Configuraciones;
using Pos.Core.Entidades.Configuraciones;
using Pos.Core.Interfaces.Configuraciones;

namespace Pos.Api.Controllers.Configs
{
    [Route("[controller]")]
    [ApiController]
    public class FormasPagoController : ControllerBase
    {
        private readonly IFormaPagoRepositorio _repositorio;
        private readonly IMapper _mapper;
        public FormasPagoController(IMapper mapper, IFormaPagoRepositorio repositorio)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.GetAllAsync(forma => forma.OrderBy(ord => ord.Descripcion));
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<FormaPagoDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormaPagoDto modelo)
        {
            var item = _mapper.Map<FormaPago>(modelo);
            var result = await _repositorio.PostAsync(item);
            if (result.Ok)
                result.Datos = _mapper.Map<FormaPagoDto>(result.Datos);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FormaPagoDto modelo)
        {
            var item = _mapper.Map<FormaPago>(modelo);
            var result = await _repositorio.PutAsync(item);
            if (result.Ok)
                result.Datos = _mapper.Map<FormaPagoDto>(result.Datos);

            return Ok(result);
        }
    }
}
