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
    public class BancosController : ControllerBase
    {
        private readonly IBancoRepositorio _repositorio;
        private readonly IMapper _mapper;
        public BancosController(IMapper mapper, IBancoRepositorio repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestFilter request)
        {
            var result = await _repositorio.GetAllAsync(banco => banco.OrderBy(ord => ord.Nombre));
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<BancoDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BancoDto modelo)
        {
            var banco = _mapper.Map<Banco>(modelo);
            var result = await _repositorio.PostAsync(banco);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BancoDto modelo)
        {
            var banco = _mapper.Map<Banco>(modelo);
            var result = await _repositorio.PutAsync(banco);
            return Ok(result);
        }
    }
}
