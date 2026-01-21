using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Empresas;
using Pos.Core.Entidades.Empresas;
using Pos.Core.Entidades.Seguridad;
using Pos.Core.Enumerables;
using Pos.Core.Interfaces.Empresas;
using Pos.Core.Modelos;
using Pos.Infraestructure.Atributos;

namespace Pos.Api.Controllers.Empresas
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmpleadoRepositorio _repositorio;
        public EmpleadosController(IMapper mapper, IEmpleadoRepositorio repositorio)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestFilter req)
        {
            var filters = ExpressionBuilder.New<Empleado>();
            if (req != null && !string.IsNullOrEmpty(req.Filter))
            {
                string filter = req.Filter.Trim();
                filters = item => item.Nombre.Contains(filter)
                    || (item.Cedula ?? string.Empty).Contains(filter)
                    || item.Empresa.Nombre.Contains(filter)
                    || (item.Correo ?? string.Empty).Contains(filter);
            }

            var result = await _repositorio.FindAndPagingAsync(
                req ?? new(),
                filters,
                item => item.OrderBy(ord => ord.Nombre),
                user => user.Empresa, item => item.Posicion!, user => user.Horario!
            );
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<EmpleadoDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmpleadoDto modelo)
        {
            var empleado = _mapper.Map<Empleado>(modelo);
            var result = await _repositorio.PostAsync(empleado);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EmpleadoDto modelo)
        {
            var empleado = _mapper.Map<Empleado>(modelo);
            var result = await _repositorio.PutAsync(empleado);
            return Ok(result);
        }
    }
}
