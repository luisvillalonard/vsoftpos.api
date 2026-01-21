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
    public class CatalogoCcController : ControllerBase
    {
        private readonly ICatalogoCcRepositorio _repositorio;
        private readonly IMapper _mapper;
        public CatalogoCcController(IMapper mapper, ICatalogoCcRepositorio repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestFilter request)
        {
            var result = await _repositorio.GetAllAsync(cc => cc.OrderBy(ord => ord.Nombre));
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<CatalogoCcDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CatalogoCcDto modelo)
        {
            var catalogo = _mapper.Map<CatalogoCc>(modelo);
            var result = await _repositorio.PostAsync(catalogo);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CatalogoCcDto modelo)
        {
            var catalogo = _mapper.Map<CatalogoCc>(modelo);
            var result = await _repositorio.PutAsync(catalogo);
            return Ok(result);
        }
    }
}
