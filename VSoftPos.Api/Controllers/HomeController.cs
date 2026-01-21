using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Pos.Core.Dto.Seguridad;
using Pos.Core.Enumerables;
using Pos.Infraestructure.Atributos;

namespace Pos.Api.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet()]
        public string Init()
        {
            return "API Facturación - En linea";
        }
    }
}
