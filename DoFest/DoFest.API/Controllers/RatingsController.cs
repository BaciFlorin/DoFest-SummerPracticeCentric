using System;
using System.Threading.Tasks;
using DoFest.Business.Activities.Models.Content.Ratings;
using DoFest.Business.Activities.Services.Interfaces;
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
        public async Task<IActionResult> Get([FromRoute] Guid activityId)
        {
            var ratings = await _ratingsService.Get(activityId);

            return Ok(ratings);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromRoute] Guid activityId, [FromBody] CreateRatingModel model)
        {
            var result = await _ratingsService.Add(activityId, model);

            return Created(result.Id.ToString(), null);

        }

        [HttpDelete("{ratingId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid activityId, [FromRoute] Guid ratingId)
        {
            await _ratingsService.Delete(activityId, ratingId);

            return NoContent();
        }
    }
}
