using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Compras;
using Pos.Core.Entidades.Compras;
using Pos.Core.Interfaces.Compras;

namespace Pos.Api.Controllers.Compras
{
    [Route("compras/pagos")]
    [ApiController]
    public class ComprasPagosController : ControllerBase
    {
        private readonly ICompraPagoRepositorio _repositorio;
        private readonly IMapper _mapper;
        public ComprasPagosController(IMapper mapper, ICompraPagoRepositorio repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.GetAllAsync(comp => comp.OrderByDescending(ord => ord.Id));
            if (result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<CompraPagoDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompraPagoDto modelo)
        {
            var pago = _mapper.Map<CompraPago>(modelo);
            var result = await _repositorio.PostAsync(pago);
            if (result.Ok)
                result.Datos = _mapper.Map<CompraPagoDto>(result.Datos);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CompraPagoDto modelo)
        {
            var pago = _mapper.Map<CompraPago>(modelo);
            var result = await _repositorio.PutAsync(pago);
            if (result.Ok)
                result.Datos = _mapper.Map<CompraPagoDto>(result.Datos);

            return Ok(result);
        }
    }
}
