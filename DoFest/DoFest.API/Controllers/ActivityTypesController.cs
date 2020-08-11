using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Models.Activity.ActivityType;
using DoFest.Business.Activities.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoFest.API.Controllers
{
    [Route("api/v1/activities/types")]
    [ApiController]
    public class ActivityTypesController:ControllerBase
    {
        private readonly IActivityTypesService _activityTypesService;

        public ActivityTypesController(IActivityTypesService activityTypesService)
        {
            _activityTypesService = activityTypesService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var (_, isFailure, value, error) = await _activityTypesService.Get();

            return Ok(value);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] CreateActivityTypeModel model)
        {
            var (_, isFailure, value, error) = await _activityTypesService.Add(model);

            if (isFailure)
            {
                return BadRequest(error);
            }

            return Created(value.Id.ToString(), value);
        }

        [HttpDelete("{activityTypeId}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid activityTypeId)
        {
            var (_, isFailure, value, error) = await _activityTypesService.Delete(activityTypeId);

            if (isFailure)
            {
                return BadRequest(error);
            }

            return Ok(new { value });
        }
    }
}
