using DoFest.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DoFest.API.Controllers
{
    [Route("api/v1/bucketlists")]
    [ApiController]
    public class BucketlistController : ControllerBase
    {
        // ****** Servicii folosite de catre controller ******
        public readonly IBucketListService _bucketListService;


        /// Constructorul public care va injecta serviciile necesare prin IoC
        public BucketlistController(IBucketListService bucketListService)
        {
            _bucketListService = bucketListService;
        }
        
        // ****** Maparea metodelor HTTP ******

        /// <summary>
        /// Metoda GetBucketLists expusa public pe web prin care se acceseaza toate BucketList-urile utilizatorilor.
        /// </summary>
        /// <returns> Un raspuns Http care semnaleaza o eroare sau statusul ok impreuna cu datele cerute prin request. </returns>
        [HttpGet("")]
        public IActionResult GetBucketLists()
        {
            // TODO: adaugarea logicii business
         
            return Ok("Message from GetBucketLists." +
                      "\n[route: GET /api/v1/bucketlists]");
        }

        [HttpGet("{bucketlistId}")]

        // TODO: adaugarea logicii business
        public async Task<IActionResult> Get([FromRoute] Guid bucketlistId)
        {
            var result = await _bucketListService.Get(bucketlistId);

            return Ok(result);
        }

        [HttpPatch("{bucketlistId}/activities/{activityId}")]

        // TODO: adaugarea logicii business
        public async Task<IActionResult> Add([FromRoute] Guid bucketlistId,[FromRoute] Guid activityId)
        {
            var result = await _bucketListService.Add(bucketlistId,activityId);

            return Ok(result);
        }
    }
}
