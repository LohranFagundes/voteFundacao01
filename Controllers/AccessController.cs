using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppVote01.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AccessController : Controller
    {
        [HttpGet]
       
        public IActionResult Get()
        {
            return Ok("Acesso permitido!");
        }
    }
}
