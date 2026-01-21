using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Inventario;
using Pos.Core.Entidades.Inventario;
using Pos.Core.Interfaces.Inventario;

namespace Pos.Api.Controllers.Inventario
{
    [Route("[controller]")]
    [ApiController]
    public class AlmacenesController : ControllerBase
    {
        private readonly IAlmacenRepositorio _repositorio;
        private readonly IMapper _mapper;
        public AlmacenesController(IMapper mapper, IAlmacenRepositorio repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.Todos();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AlmacenDto modelo)
        {
            var almacen = _mapper.Map<Almacen>(modelo);
            var result = await _repositorio.PostAsync(almacen);
            if (result.Ok)
                result.Datos = _mapper.Map<AlmacenDto>(result.Datos);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AlmacenDto modelo)
        {
            var almacen = _mapper.Map<Almacen>(modelo);
            var result = await _repositorio.PutAsync(almacen);
            if (result.Ok)
                result.Datos = _mapper.Map<AlmacenDto>(result.Datos);

            return Ok(result);
        }
    }
}
