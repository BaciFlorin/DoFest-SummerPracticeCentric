using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DoFest.Business.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoFest.API.Controllers
{
    [Route("/api/v1/admin/")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            this._adminService = adminService;
        }

        [HttpGet("users")]
        [Authorize]
        public async Task<IActionResult> GetUsers()
        {
            var (_, isFailure, result, error) = await _adminService.GetUsers();
            if (isFailure)
            {
                return BadRequest(error);
            }

            return Ok(result);
        }

        [HttpGet("userTypes")]
        [Authorize]
        public async Task<IActionResult> GetUserTypes()
        {
            var (_, isFailure, result, error) = await _adminService.GetUserTypes();
            if (isFailure)
            {
                return BadRequest(error);
            }

            return Ok(result);
        }

        [HttpPatch("user/{userId}/usertype/toggle")]
        [Authorize]
        public async Task<IActionResult> ToggleUserType([FromRoute] Guid userId)
        {
            var (_, isFailure, result, error) = await _adminService.ToggleUserType(userId);
            if (isFailure)
            {
                return BadRequest(error);
            }

            return Ok(result);
        }

    }
}
