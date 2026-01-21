using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Ventas;
using Pos.Core.Entidades.Ventas;
using Pos.Core.Interfaces.Ventas;
using Pos.Core.Modelos;
using Pos.Infraestructure.Extensiones;

namespace Pos.Api.Controllers.Ventas
{
    [Route("[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFacturaRepositorio _repositorio;
        public FacturasController(
            IMapper mapper, 
            IFacturaRepositorio repositorio
        )
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var user = await Request.GetUser();
            if (user == null)
                return Ok(new ResponseResult(false, "Código de usuario inválido"));

            var result = await _repositorio.FindAsync(
                x => x.EmpresaId == user.Empresa.Id,
                x => x.FacturaTipo, x => x.Empresa, x => x.Comprobante!, x => x.Cliente, x => x.FacturaDetalle
            );
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<FacturaDto>>(result.Datos);
            return Ok(result);
        }

        [HttpGet("abiertas")]
        public async Task<IActionResult> GetAbiertasAsync()
        {
            var user = await Request.GetUser();
            if (user == null)
                return Ok(new ResponseResult(false, "Código de usuario inválido"));

            var result = await _repositorio.FindAsync(
                x => x.EmpresaId == user.Empresa.Id && x.Abierta == true,
                x => x.FacturaTipo, x => x.Empresa, x => x.Comprobante!, x => x.Cliente, x => x.FacturaDetalle
            );
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<FacturaDto>>(result.Datos);
            return Ok(result);
        }

        [HttpGet("reimprimir/{empresaId}")]
        public async Task<IActionResult> GetReimprimirAsync(long empresaId)
        {
            var result = await _repositorio.FindAsync(
                x => x.Abierta == true && x.EmpresaId == empresaId,
                x => x.FacturaTipo, x => x.FacturaDetalle, x => x.Empresa, x => x.Comprobante!, x => x.Cliente
            );
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<FacturaDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FacturaDto modelo)
        {
            // Obtengo el usuario de la peticion
            var user = await Request.GetUser();
            if (user == null)
                return Ok(new ResponseResult(false, "Código de usuario inválido"));

            // Establezco la empresa del usuario a la factaura
            modelo.Empresa = user.Empresa;

            // Establezco la factura
            var factura = _mapper.Map<Factura>(modelo);

            // Guardo la factura
            var result = await _repositorio.PostAsync(factura);

            // Retorno el resultado
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FacturaDto modelo)
        {
            var factura = _mapper.Map<Factura>(modelo);
            var result = await _repositorio.PutAsync(factura);
            return Ok(result);
        }

        [HttpPost("Pago")]
        public async Task<IActionResult> PostPago([FromBody] FacturaPagoDto[] items)
        {
            // Obtengo el usuario de la peticion
            var user = await Request.GetUser();
            if (user == null)
                return Ok(new ResponseResult(false, "Código de usuario inválido"));

            // Establezco la factura
            var pagos = _mapper.Map<IEnumerable<FacturaPago>>(items);

            // Guardo la factura
            var result = await _repositorio.PostPagoAsync(pagos.ToArray());

            // Retorno el resultado
            return Ok(result);
        }
    }
}
