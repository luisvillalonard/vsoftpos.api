using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Contabilidad;
using Pos.Core.Entidades.Contabilidad;
using Pos.Core.Interfaces.Contabilidad;

namespace Pos.Api.Controllers.Contabilidad
{
    [Route("[controller]")]
    [ApiController]
    public class ImpuestosController : ControllerBase
    {
        private readonly IImpuestoRepositorio _repositorio;
        private readonly IMapper _mapper;

        public ImpuestosController(IImpuestoRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.GetAllAsync(imp => imp.OrderBy(ord => ord.Nombre));
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<ImpuestoDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ImpuestoDto modelo)
        {
            var item = _mapper.Map<Impuesto>(modelo);
            var result = await _repositorio.PostAsync(item);
            if (result.Ok)
                result.Datos = _mapper.Map<ImpuestoDto>(result.Datos);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ImpuestoDto modelo)
        {
            var item = _mapper.Map<Impuesto>(modelo);
            var result = await _repositorio.PutAsync(item);
            if (result.Ok)
                result.Datos = _mapper.Map<ImpuestoDto>(result.Datos);

            return Ok(result);
        }
    }
}
