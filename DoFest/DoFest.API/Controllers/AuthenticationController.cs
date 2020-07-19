using DoFest.Entities.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DoFest.API.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        // ****** Servicii folosite de catre controller ******
        //.........
        // TODO: adaugarea serviciilor


        /// Constructorul public care va injecta serviciile necesare prin IoC
        public AuthenticationController()
        {
            // TODO
        }

        // ****** Maparea metodelor HTTP ******


        [HttpPost("/login")]
        public IActionResult Login([FromBody] User userModel)
        {
            // TODO: adaugarea logicii business
            // TODO: adaugarea sintaxei pentru async/await
            return Ok("Message from Login." +
                      "\n[route: POST /api/v1/auth/login]");
        }

        [HttpPost("/register")]
        public IActionResult Register([FromBody] User userModel)
        {
            // TODO: adaugarea logicii business
            // TODO: adaugarea sintaxei pentru async/await
            return Ok("Message from Register." +
                      "\n[route: GET /api/v1/auth/register]");
        }

        [HttpPut("/changepassword")]
        public IActionResult ChangePassword()
        {
            // TODO: adaugarea logicii business
            // TODO: adaugarea sintaxei pentru async/await
            return Ok("Message from ChangePassword." +
                      "\n[route: GET /api/v1/auth/changepassword]");
        }

    }
}
