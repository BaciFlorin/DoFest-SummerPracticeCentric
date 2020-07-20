using DoFest.Business.Models.Authentication;
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
        public IActionResult Login([FromBody] LoginModel model)
        {
            // TODO: adaugarea logicii business
            // TODO: adaugarea sintaxei pentru async/await
            return Ok("Message from Login." +
                      "\n[route: POST /api/v1/auth/login] " +
                      $"\nmodel: username:{model.Username} password:{model.PasswordHash}");
        }

        
        [HttpPost("/register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            // TODO: adaugarea logicii business
            // TODO: adaugarea sintaxei pentru async/await
            return Ok("Message from Register." +
                      "\n[route: GET /api/v1/auth/register] " +
                      $"\nuserModel: username:{model.Username} email:{model.Email} passwordHash:{model.PasswordHash}");
        }

        [HttpPut("/changepassword")]
        public IActionResult ChangePassword([FromBody] NewPasswordModel model)
        {

            // TODO: adaugarea logicii business
            // TODO: adaugarea sintaxei pentru async/await
            return Ok("Message from ChangePassword." +
                      "\n[route: GET /api/v1/auth/changepassword]" +
                      $"\npassword: {model.NewPassword}");
        }

    }
}
