using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Contabilidad;
using Pos.Core.Interfaces.Contabilidad;

namespace Pos.Api.Controllers.Contabilidad
{
    [Route("comprobantes/tipos")]
    [ApiController]
    public class ComprobantesTiposController : ControllerBase
    {
        private readonly IComprobanteTipoRepositorio _repositorio;
        private readonly IMapper _mapper;
        public ComprobantesTiposController(IMapper mapper, IComprobanteTipoRepositorio repositorio)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.GetAllAsync(tipo => tipo.OrderBy(ord => ord.Descripcion));
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<ComprobanteTipoDto>>(result.Datos);
            return Ok(result);
        }
    }
}
