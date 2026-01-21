using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Inventario;
using Pos.Core.Entidades.Inventario;
using Pos.Core.Interfaces.Inventario;
using Pos.Core.Modelos;

namespace Pos.Api.Controllers.Inventario
{
    [Route("[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepositorio _repositorio;
        private readonly IStockRepositorio _repoStock;
        private readonly IMapper _mapper;
        public ProductosController(
            IMapper mapper, 
            IProductoRepositorio repositorio,
            IStockRepositorio repoStock)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _repoStock = repoStock ?? throw new ArgumentNullException(nameof(repoStock));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestFilter request)
        {
            var result = await _repositorio.Todos(request);
            return Ok(result);
        }

        [HttpGet("ToList")]
        public async Task<IActionResult> GetAllToList()
        {
            var result = await _repoStock.GetAllAsync(
                prod => prod.OrderBy(ord => ord.Producto.Nombre),
                prod => prod.Producto, prod => prod.Producto.Grupo!, prod => prod.Producto.Impuesto);
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<ProductoPosDto>>(result.Datos)
                .Select(prod => { prod.Id = 0; prod.Cantidad = 0; return prod; }).AsEnumerable();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoDto modelo)
        {
            var producto = _mapper.Map<Producto>(modelo);
            var result = await _repositorio.PostAsync(producto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductoDto modelo)
        {
            var producto = _mapper.Map<Producto>(modelo);
            var result = await _repositorio.PutAsync(producto);
            return Ok(result);
        }
    }
}
