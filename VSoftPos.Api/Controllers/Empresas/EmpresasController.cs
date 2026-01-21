using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Empresas;
using Pos.Core.Entidades.Empresas;
using Pos.Core.Interfaces.Empresas;

namespace Pos.Api.Controllers.Empresas
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmpresaRepositorio _repositorio;
        public EmpresasController(IMapper mapper, IEmpresaRepositorio repositorio)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.GetAllAsync(emp => emp.OrderBy(ord => ord.Nombre));
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<EmpresaDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmpresaDto modelo)
        {
            var empresa = _mapper.Map<Empresa>(modelo);
            var result = await _repositorio.PostAsync(empresa);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EmpresaDto modelo)
        {
            var empresa = _mapper.Map<Empresa>(modelo);
            var result = await _repositorio.PutAsync(empresa);
            return Ok(result);
        }
    }
}
