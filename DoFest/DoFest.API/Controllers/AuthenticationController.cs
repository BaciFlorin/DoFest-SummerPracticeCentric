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

        /// <summary>
        /// Aceasta metoda primeste un LoginModel ce contine datele specifice actiunii de login, foloseste serviciul
        /// specific acestei actiuni si returneaza un HTTP response catre client potrivit actiunilor realizate de serviciu.
        /// </summary>
        /// <param name="model"> Un model de data ce reprezinta datele necesare de login. </param>
        /// <returns> Un raspuns Http care semnaleaza o eroare sau statusul OK impreuna cu date optionale returnate prin request. </returns>
        [HttpPost("/login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // TODO: adaugarea logicii business
            // TODO: adaugarea sintaxei pentru async/await
            return Ok("Message from Login." +
                      "\n[route: POST /api/v1/auth/login] " +
                      $"\nmodel: username:{model.Username} password:{model.PasswordHash}");
        }

        /// <summary>
        /// Aceasta metoda primeste un RegisterModel ce contine datele specifice actiunii de register, foloseste serviciul
        /// specific acestei actiuni si returneaza un HTTP response catre client potrivit actiunilor realizate de serviciu.
        /// </summary>
        /// <param name="model"> Un model de data ce reprezinta datele necesare pentru operatia de register. </param>
        /// <returns> Un raspuns Http care semnaleaza o eroare sau statusul CREATED impreuna cu date optionale returnate prin request. </returns>
        [HttpPost("/register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            // TODO: adaugarea logicii business
            // TODO: adaugarea sintaxei pentru async/await
            return Ok("Message from Register." +
                      "\n[route: GET /api/v1/auth/register] " +
                      $"\nuserModel: username:{model.Username} email:{model.Email} passwordHash:{model.PasswordHash}");
        }

        /// <summary>
        /// Aceasta metoda primeste un NewPasswordModel ce contine datele specifice actiunii de changepassword, foloseste serviciul
        /// specific acestei actiuni si returneaza un HTTP response catre client potrivit actiunilor realizate de serviciu.
        /// </summary>
        /// <param name="model"> Un model de data ce reprezinta datele necesare pentru operatia de change password. </param>
        /// <returns> Un raspuns Http care semnaleaza o eroare sau statusul OK impreuna cu date optionale returnate prin request. </returns>
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
