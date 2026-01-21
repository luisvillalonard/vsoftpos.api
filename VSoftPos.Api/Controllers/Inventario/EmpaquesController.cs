using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Inventario;
using Pos.Core.Entidades.Inventario;
using Pos.Core.Interfaces.Inventario;

namespace Pos.Api.Controllers.Almacenes
{
    [Route("[controller]")]
    [ApiController]
    public class EmpaquesController : ControllerBase
    {
        private readonly IEmpaqueRepositorio _repositorio;
        private readonly IMapper _mapper;
        public EmpaquesController(IMapper mapper, IEmpaqueRepositorio repositorio)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.GetAllAsync(emp => emp.OrderBy(ord => ord.Nombre));
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<EmpaqueDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmpaqueDto modelo)
        {
            var empaque = _mapper.Map<Empaque>(modelo);
            var result = await _repositorio.PostAsync(empaque);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EmpaqueDto modelo)
        {
            var empaque = _mapper.Map<Empaque>(modelo);
            var result = await _repositorio.PutAsync(empaque);
            return Ok(result);
        }
    }
}
