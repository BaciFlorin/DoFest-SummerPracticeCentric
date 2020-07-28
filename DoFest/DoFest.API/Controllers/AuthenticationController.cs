using System.Threading.Tasks;
using DoFest.Business.Identity.Models;
using DoFest.Business.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoFest.API.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginModelRequest modelRequest)
        {
            var result = await _authenticationService.Login(modelRequest);
            if (result == null)
            {
                return BadRequest("Incorrect username or password");
            }

            return Ok(result);
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var result = await _authenticationService.Register(model);

            if (result == null)
            {
                return BadRequest("Incorrect input data!");
            }

            return Created(result.Id.ToString(), null);
        }

        [HttpPut("/change-password")]
        [Authorize]
        public IActionResult ChangePassword([FromBody] NewPasswordModelRequest modelRequest)
        {
            var result = _authenticationService.ChangePassword(modelRequest);
            return Ok(result.Result);
        }

    }
}
