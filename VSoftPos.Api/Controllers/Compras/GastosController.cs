using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Compras;
using Pos.Core.Entidades.Compras;
using Pos.Core.Interfaces.Compras;

namespace Pos.Api.Controllers.Gastos
{
    [Route("[controller]")]
    [ApiController]
    public class GastosController : ControllerBase
    {
        private readonly IGastoRepositorio _repositorio;
        private readonly IMapper _mapper;
        public GastosController(IMapper mapper, IGastoRepositorio repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.GetAllAsync(
                gasto => gasto.OrderBy(ord => ord.Tipo.Nombre), 
                gasto => gasto.Tipo, gasto => gasto.Empleado!, gasto => gasto.Empresa
            );
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<GastoDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GastoDto modelo)
        {
            var gasto = _mapper.Map<Gasto>(modelo);
            var result = await _repositorio.PostAsync(gasto);
            if (result.Ok)
                result.Datos = _mapper.Map<GastoDto>(result.Datos);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] GastoDto modelo)
        {
            var gasto = _mapper.Map<Gasto>(modelo);
            var result = await _repositorio.PutAsync(gasto);
            if (result.Ok)
                result.Datos = _mapper.Map<GastoDto>(result.Datos);

            return Ok(result);
        }
    }
}
