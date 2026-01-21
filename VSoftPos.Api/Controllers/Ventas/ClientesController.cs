using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Ventas;
using Pos.Core.Entidades.Ventas;
using Pos.Core.Interfaces.Ventas;
using Pos.Core.Modelos;

namespace Pos.Api.Controllers.Ventas
{
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepositorio _repositorio;
        private readonly IMapper _mapper;
        public ClientesController(IMapper mapper, IClienteRepositorio repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestFilter request)
        {
            var result = await _repositorio.GetAllAsync(
                cli => cli.OrderBy(ord => ord.Nombre),
                cli => cli.CondicionPago!, cli => cli.Comprobante!, cli => cli.Credito);
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<ClienteDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDto modelo)
        {
            var cliente = _mapper.Map<Cliente>(modelo);
            var result = await _repositorio.PostAsync(cliente);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ClienteDto modelo)
        {
            var cliente = _mapper.Map<Cliente>(modelo);
            var result = await _repositorio.PutAsync(cliente);
            return Ok(result);
        }
    }
}
