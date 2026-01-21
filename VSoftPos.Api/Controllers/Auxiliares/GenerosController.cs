using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Auxiliares;
using Pos.Core.Interfaces.Auxiliares;

namespace Pos.Api.Controllers.Auxiliares
{
    [Route("[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IGeneroRepositorio _repositorio;
        private readonly IMapper _mapper;
        public GenerosController(IMapper mapper, IGeneroRepositorio repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.GetAllAsync(gen => gen.OrderBy(ord => ord.Descripcion));
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<GeneroDto>>(result.Datos);
            return Ok(result);
        }
    }
}
