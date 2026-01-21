using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Dto.Auxiliares;
using Pos.Core.Entidades.Auxiliares;
using Pos.Core.Interfaces.Auxiliares;

namespace Pos.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BilletesController : ControllerBase
    {
        private readonly IBilleteRepositorio _repositorio;
        private readonly IMapper _mapper;
        public BilletesController(IMapper mapper, IBilleteRepositorio repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repositorio.GetAllAsync(bill => bill.OrderBy(ord => ord.Valor));
            if (!result.Ok)
                return Ok(result);

            result.Datos = _mapper.Map<IEnumerable<BilleteDto>>(result.Datos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BilleteDto modelo)
        {
            var billete = _mapper.Map<Billete>(modelo);
            var result = await _repositorio.PostAsync(billete);
            if (result.Ok)
                result.Datos = _mapper.Map<BilleteDto>(result.Datos);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BilleteDto modelo)
        {
            var billete = _mapper.Map<Billete>(modelo);
            var result = await _repositorio.PutAsync(billete);
            if (result.Ok)
                result.Datos = _mapper.Map<BilleteDto>(result.Datos);

            return Ok(result);
        }
    }
}
