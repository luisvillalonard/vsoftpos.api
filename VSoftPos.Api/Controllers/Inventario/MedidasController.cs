using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Inventario;
using Pos.Core.Entidades.Inventario;
using Pos.Core.Interfaces.Inventario;

namespace Pos.Api.Controllers.Inventario
{
    [Route("[controller]")]
    [ApiController]
    public class MedidasController : ControllerBase
    {
        private readonly IMedidaRepositorio _repositorio;
        private readonly IMapper _mapper;

        public MedidasController(IMedidaRepositorio repositorio, IMapper mapper)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.GetAllAsync(med => med.OrderBy(ord => ord.Nombre));
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<MedidaDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MedidaDto modelo)
        {
            var medida = _mapper.Map<Medida>(modelo);
            var result = await _repositorio.PostAsync(medida);
            if (result.Ok)
                result.Datos = _mapper.Map<MedidaDto>(result.Datos);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] MedidaDto modelo)
        {
            var medida = _mapper.Map<Medida>(modelo);
            var result = await _repositorio.PutAsync(medida);
            if (result.Ok)
                result.Datos = _mapper.Map<MedidaDto>(result.Datos);

            return Ok(result);
        }
    }
}
