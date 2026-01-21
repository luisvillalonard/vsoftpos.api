using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Compras;
using Pos.Core.Entidades.Compras;
using Pos.Core.Interfaces.Compras;

namespace Pos.Api.Controllers.Gastos
{
    [Route("gastos/tipos")]
    [ApiController]
    public class GastosTiposController : ControllerBase
    {
        private readonly IGastoTipoRepositorio _repositorio;
        private readonly IMapper _mapper;
        public GastosTiposController(IMapper mapper, IGastoTipoRepositorio repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.GetAllAsync(tipo => tipo.OrderBy(ord => ord.Nombre));
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<GastoTipoDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(GastoTipoDto modelo)
        {
            var tipo = _mapper.Map<GastoTipo>(modelo);
            var result = await _repositorio.PostAsync(tipo);
            if (result.Ok)
                result.Datos = _mapper.Map<GastoTipoDto>(result.Datos);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(GastoTipoDto modelo)
        {
            var tipo = _mapper.Map<GastoTipo>(modelo);
            var result = await _repositorio.PutAsync(tipo);
            if (result.Ok)
                result.Datos = _mapper.Map<GastoTipoDto>(result.Datos);

            return Ok(result);
        }
    }
}
