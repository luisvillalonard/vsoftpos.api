using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Inventario;
using Pos.Core.Entidades.Inventario;
using Pos.Core.Interfaces.Inventario;
using Pos.Core.Modelos;

namespace Pos.Api.Controllers.Inventario
{
    [Route("medidas/unidades")]
    [ApiController]
    public class UnidadesMedidasController : ControllerBase
    {
        private readonly IUnidadRepositorio _repositorio;
        private readonly IMapper _mapper;

        public UnidadesMedidasController(IUnidadRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestFilter request)
        {
            var result = await _repositorio.Todas(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UnidadDto modelo)
        {
            var unidad = _mapper.Map<Unidad>(modelo);
            var result = await _repositorio.PostAsync(unidad);
            if (result.Ok)
                result.Datos = _mapper.Map<UnidadDto>(result.Datos);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UnidadDto modelo)
        {
            var unidad = _mapper.Map<Unidad>(modelo);
            var result = await _repositorio.PutAsync(unidad);
            if (result.Ok)
                result.Datos = _mapper.Map<UnidadDto>(result.Datos);

            return Ok(result);
        }
    }
}
