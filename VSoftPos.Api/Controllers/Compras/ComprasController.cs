using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Compras;
using Pos.Core.Entidades;
using Pos.Core.Entidades.Compras;
using Pos.Core.Interfaces.Compras;
using Pos.Core.Modelos;

namespace Pos.Api.Controllers.Compras
{
    [Route("[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly ICompraRepositorio _repositorio;
        private readonly IMapper _mapper;
        public ComprasController(IMapper mapper, ICompraRepositorio repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestFilter request)
        {
            var result = await _repositorio.GetAllAsync(comp => comp.OrderByDescending(ord => ord.Id));
            if (result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<CompraDto>>(result.Datos);
            return Ok(result);
        }

        [HttpGet("pago/{id}")]
        public async Task<IActionResult> PagoAsync(int id)
        {
            //var result = await _repositorio.GetAllAsync(
            //    x => x.Id == id,
            //    x => x.Almacen, x => x.CompraDetalle, x => x.Empresa, x => x.Suplidor);
            //var compra = result.Datos as Compra;
            //if (compra == null)
            //    return Ok(new ResponseResult("No fue posible obtener los datos de la compra."));

            //var pago = new dtoCompraPago()
            //{
            //    CompraId = compra.Id,
            //    NumeroRecibo = compra.NumeroFactura,
            //    Suplidor = compra.Suplidor.Nombre,
            //    MontoFactura = compra.MontoFactura,
            //    MontoPagado = compra.MontoFactura - compra.MontoPagado,
            //    Fecha = DateTime.Now.ToString("yyyy-MM-dd")
            //};
            //result.Datos = pago;
            return await Task.FromResult(Ok());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompraDto modelo)
        {
            var compra = _mapper.Map<Compra>(modelo);
            compra.CompraDetalle.Clear();
            //foreach (var detalleDto in modelo.Detalle)
            //{
            //    var detalle = _mapper.Map<CompraDetalle>(detalleDto);
            //    compra.CompraDetalle.Add(detalle);
            //}

            var result = await _repositorio.PostAsync(compra);
            if (result.Ok)
                result.Datos = _mapper.Map<CompraDto>(result.Datos);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CompraDto modelo)
        {
            var compra = _mapper.Map<Compra>(modelo);
            var result = await _repositorio.PutAsync(compra);
            if (result.Ok)
                result.Datos = _mapper.Map<CompraDto>(result.Datos);

            return Ok(result);
        }
    }
}
