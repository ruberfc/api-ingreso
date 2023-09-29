using Microsoft.AspNetCore.Mvc;
using api_ingreso.src.Service;

namespace api_ingreso.src.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class PuertaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllPuerta()
        {
            return Ok(PuertaService.GetAllPuerta());
        }
    }
}
