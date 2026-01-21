using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Contabilidad;
using Pos.Core.Entidades.Contabilidad;
using Pos.Core.Interfaces.Contabilidad;

namespace Pos.Api.Controllers.Contabilidad
{
    [Route("comprobantes/secuencias")]
    [ApiController]
    public class ComprobantesSecuenciasController : ControllerBase
    {
        private readonly IComprobanteSecuenciaRepositorio _repositorio;
        private readonly IMapper _mapper;
        public ComprobantesSecuenciasController(IMapper mapper, IComprobanteSecuenciaRepositorio repositorio)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.Todas();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ComprobanteSecuenciaDto modelo)
        {
            var comprobanteSecuencia = _mapper.Map<ComprobanteSecuencia>(modelo);
            var result = await _repositorio.PostAsync(comprobanteSecuencia);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ComprobanteSecuenciaDto modelo)
        {
            var comprobanteSecuencia = _mapper.Map<ComprobanteSecuencia>(modelo);
            var result = await _repositorio.PutAsync(comprobanteSecuencia);
            return Ok(result);
        }
    }
}
