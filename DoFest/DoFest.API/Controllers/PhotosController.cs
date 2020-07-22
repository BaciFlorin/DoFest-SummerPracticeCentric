using System;
using System.Threading.Tasks;
using DoFest.Business.Models.Content.Photos;
using DoFest.Business.Services.Interfaces;
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
        public async Task<IActionResult> Get([FromRoute] Guid activityId)
        {
            var result = await _photosService.Get(activityId);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromRoute] Guid activityId, [FromBody] CreatePhotoModel model)
        {
            var result = await _photosService.Add(activityId, model);

            return Created(result.Id.ToString(), null);
        }

        [HttpDelete("/photoId")]
        public async Task<IActionResult> Delete([FromRoute] Guid activityId, [FromRoute] Guid photoId)
        {
            await _photosService.Delete(activityId, photoId);

            return NoContent();
        }

    }

}
