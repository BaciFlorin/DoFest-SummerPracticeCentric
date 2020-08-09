using System.Threading.Tasks;
using CSharpFunctionalExtensions;
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

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginModelRequest modelRequest)
        {
            var (_, isFailure, value, error) = await _authenticationService.Login(modelRequest);
            if (isFailure)
                return BadRequest(error);
            return Ok(value);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var (_, isFailure, value, error) = await _authenticationService.Register(model);
            if (isFailure)
                return BadRequest(error);
            return Created(value,null);
        }

        [HttpPut("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] NewPasswordModelRequest modelRequest)
        {
            var(_, isFailure, value, error) = await _authenticationService.ChangePassword(modelRequest);
            if (isFailure)
                return BadRequest(error);
            return Ok(new{value});
        }
    }
}
