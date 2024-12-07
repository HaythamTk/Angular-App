using ApiTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Test : ControllerBase
    {
        [HttpPost]
        public ActionResult CreateProduct([FromForm] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("hello");
            }
            return Ok();

        }

    }
}
