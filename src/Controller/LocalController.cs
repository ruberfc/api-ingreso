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
    public class LocalController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllLocal()
        {
            return Ok(LocalService.GetAllLocal());
        }

        [HttpGet("{id}")]
        public IActionResult GetLocalById(int id)
        {
            return Ok(LocalService.GetLocalById(id));
        }


    }
}