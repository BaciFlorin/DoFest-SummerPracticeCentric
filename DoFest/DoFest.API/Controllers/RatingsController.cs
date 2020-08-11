using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Models.Content.Ratings;
using DoFest.Business.Activities.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoFest.API.Controllers
{
    [Route("api/v1/activities/{activityId}/ratings")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingsService _ratingsService;

        public RatingsController(IRatingsService ratingsService)
        {
            this._ratingsService = ratingsService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] Guid activityId)
        {
            var (_, isFailure, value, error) = await _ratingsService.Get(activityId);

            if (isFailure)
            {
                return BadRequest(error);
            }

            return Ok(value);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromRoute] Guid activityId, [FromBody] CreateRatingModel model)
        {
            var (_, isFailure, value, error) = await _ratingsService.Add(activityId, model);

            if (isFailure)
            {
                return BadRequest(error);
            }

            return Created(value.Id.ToString(), null);

        }


    }
}
