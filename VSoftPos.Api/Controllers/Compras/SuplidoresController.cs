using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Compras;
using Pos.Core.Entidades.Compras;
using Pos.Core.Interfaces.Compras;

namespace Pos.Api.Controllers.Compras
{
    [ApiController]
    [Route("[controller]")]
    public class SuplidoresController : ControllerBase
    {
        private readonly ISuplidorRepositorio _repositorio;
        private readonly IMapper _mapper;
        public SuplidoresController(IMapper mapper, ISuplidorRepositorio repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.GetAllAsync(
                sup => sup.OrderBy(ord => ord.Nombre),
                sup => sup.CondicionPago!);
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<SuplidorDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SuplidorDto modelo)
        {
            var suplidor = _mapper.Map<Suplidor>(modelo);
            var result = await _repositorio.PostAsync(suplidor);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SuplidorDto modelo)
        {
            var suplidor = _mapper.Map<Suplidor>(modelo);
            var result = await _repositorio.PutAsync(suplidor);
            return Ok(result);
        }
    }
}
