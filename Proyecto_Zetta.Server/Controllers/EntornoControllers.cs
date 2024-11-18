
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Zetta.Server.Controllers
{
    [Route("api/configuracion")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfiguracionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("entorno")]
        public ActionResult<string> ObtenerEntorno()
        {
            var entorno = _configuration["ASPNETCORE_ENVIRONMENT"];
            return Ok(entorno);  // Devuelve el valor como un string
        }
    }

}
