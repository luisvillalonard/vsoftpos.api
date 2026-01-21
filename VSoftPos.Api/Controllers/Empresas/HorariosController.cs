using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Empresas;
using Pos.Core.Entidades.Empresas;
using Pos.Core.Interfaces.Empresas;

namespace Pos.Api.Controllers.Empresas
{
    [ApiController]
    [Route("[controller]")]
    public class HorariosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHorarioRepositorio _repositorio;

        public HorariosController(IMapper mapper, IHorarioRepositorio repositorio)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.GetAllAsync(
                hor => hor.OrderBy(ord => ord.Nombre),
                hor => hor.Empresa, hor => hor.Empleado
            );
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<HorarioDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HorarioDto modelo)
        {
            var horario = _mapper.Map<Horario>(modelo);
            var result = await _repositorio.PostAsync(horario);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] HorarioDto modelo)
        {
            var horario = _mapper.Map<Horario>(modelo);
            var result = await _repositorio.PutAsync(horario);
            return Ok(result);
        }
    }
}
