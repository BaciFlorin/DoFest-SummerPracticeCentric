using System;
using System.Threading.Tasks;
using DoFest.Business.Activities.Models.Activity.ActivityType;
using DoFest.Business.Activities.Services.Interfaces;
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
        public async Task<IActionResult> Get()
        {
            var ratings = await _activityTypesService.Get();

            return Ok(ratings);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateActivityTypeModel model)
        {
            var activityType = await _activityTypesService.Add(model);

            return Created(activityType.Id.ToString(), null);
        }
    }
}
