using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoFest.Business.Models.Photos;
using DoFest.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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

            return Ok();
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
            return NoContent();
        }

    }

}
