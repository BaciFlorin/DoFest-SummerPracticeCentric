using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Models.Content.Photos;
using DoFest.Business.Activities.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoFest.API.Controllers
{
    [Route("api/v1/activities/{activityId}/photos")]
    [ApiController]
    
    public class PhotosController : ControllerBase
    {
        private readonly IPhotosService _photosService;

        public PhotosController(IPhotosService photosService)
        {
            _photosService = photosService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] Guid activityId)
        {
            var (_, isFailure, value, error) = await _photosService.Get(activityId);

            if (isFailure)
            {
                return BadRequest(error);
            }

            return Ok(value);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromRoute] Guid activityId, [FromForm] CreatePhotoModel model)
        {
            var (_, isFailure, value, error) = await _photosService.Add(activityId, model);
            if (isFailure)
            {
                return BadRequest(error);
            }

            return Created(value.Id.ToString(), null);
        }

        [HttpDelete("{photoId}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid activityId, [FromRoute] Guid photoId)
        {
            var(_, isFailure, value, error) = await _photosService.Delete(activityId, photoId);

            if (isFailure)
            {
                return BadRequest(error);
            }

            return NoContent();
        }

    }

}
