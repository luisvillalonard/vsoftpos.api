using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Empresas;
using Pos.Core.Entidades.Empresas;
using Pos.Core.Enumerables;
using Pos.Core.Interfaces.Empresas;
using Pos.Infraestructure.Atributos;

namespace Pos.Api.Controllers.Empresas
{
    [ApiController]
    [Route("[controller]")]
    public class PosicionesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPosicionRepositorio _repositorio;
        public PosicionesController(IMapper mapper, IPosicionRepositorio repositorio)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.GetAllAsync(
                pos => pos.OrderBy(ord => ord.Nombre),
                pos => pos.Empresa
            );
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<PosicionDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PosicionDto modelo)
        {
            var posicion = _mapper.Map<Posicion>(modelo);
            var result = await _repositorio.PostAsync(posicion);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PosicionDto modelo)
        {
            var posicion = _mapper.Map<Posicion>(modelo);
            var result = await _repositorio.PutAsync(posicion);
            return Ok(result);
        }
    }
}
