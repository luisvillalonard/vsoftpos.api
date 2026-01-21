using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Contabilidad;
using Pos.Core.Entidades.Contabilidad;
using Pos.Core.Interfaces.Contabilidad;
using Pos.Core.Modelos;

namespace Pos.Api.Controllers.Contabilidad
{
    [Route("[controller]")]
    [ApiController]
    public class ComprobantesController : ControllerBase
    {
        private readonly IComprobanteRepositorio _repositorio;
        private readonly IMapper _mapper;
        public ComprobantesController(IMapper mapper, IComprobanteRepositorio repositorio)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestFilter request)
        {
            var result = await _repositorio.Todos(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ComprobanteDto modelo)
        {
            var comprobante = _mapper.Map<Comprobante>(modelo);
            var result = await _repositorio.PostAsync(comprobante);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ComprobanteDto modelo)
        {
            var comprobante = _mapper.Map<Comprobante>(modelo);
            var result = await _repositorio.PutAsync(comprobante);
            return Ok(result);
        }
    }
}
