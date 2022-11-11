using Microsoft.AspNetCore.Mvc;

namespace testReactApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = new[]
            {
                new {Name = "Bohdan"},
                new {Name = "Denys"},
                new {Name = "EEEE"},
                new {Name = "Halyna"},
                new {Name = "Vadym"},
            };
            return Ok(users);
        }
    }
}
