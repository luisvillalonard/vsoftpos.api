using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Contabilidad;
using Pos.Core.Entidades.Contabilidad;
using Pos.Core.Interfaces.Contabilidad;
using Pos.Core.Modelos;

namespace Pos.Api.Controllers.Contabilidad
{
    [Route("bancos/cuentas")]
    [ApiController]
    public class CuentasBancosController : ControllerBase
    {
        private readonly ICuentaBancoRepositorio _repositorio;
        private readonly IMapper _mapper;
        public CuentasBancosController(IMapper mapper, ICuentaBancoRepositorio repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestFilter request)
        {
            var result = await _repositorio.GetAllAsync(
                cuenta => cuenta.OrderBy(ord => ord.Banco.Nombre),
                cuenta => cuenta.Empresa, cuenta => cuenta.Banco);
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<CuentaBancoDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CuentaBancoDto modelo)
        {
            var cuenta = _mapper.Map<CuentaBanco>(modelo);
            var result = await _repositorio.PostAsync(cuenta);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CuentaBancoDto modelo)
        {
            var cuenta = _mapper.Map<CuentaBanco>(modelo);
            var result = await _repositorio.PutAsync(cuenta);
            return Ok(result);
        }
    }
}
