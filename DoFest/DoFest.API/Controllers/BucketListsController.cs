using DoFest.Business.Activities.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using DoFest.Business.Activities.Models.BucketList;

namespace DoFest.API.Controllers
{
    [Route("/api/v1/bucketlists")]
    [ApiController]
    [Authorize]
    public class BucketListsController : ControllerBase
    {
        // ****** Servicii folosite de catre controller ******

        public readonly IBucketListService _bucketListService;

        /// Constructorul public care va injecta serviciile necesare prin IoC
        public BucketListsController(IBucketListService bucketListService)
        {
            _bucketListService = bucketListService;
        }

        // ****** Maparea metodelor HTTP ******

        /// <summary>
        /// Metoda GetBucketLists expusa public pe web prin care se acceseaza toate BucketList-urile utilizatorilor.
        /// </summary>
        /// <returns> Un raspuns Http care semnaleaza o eroare sau statusul ok impreuna cu datele cerute prin request. </returns>
        [HttpGet("")]
        public async Task<IActionResult> GetBucketList()
        {
            var (_, _, result, _) = await _bucketListService.GetBucketLists();
            return Ok(result);
        }

        /// <summary>
        /// Metoda expusa pe web care returneaza un bucket list impreuna cu id activitatilor asociate.
        /// </summary>
        /// <param name="bucketlistId"> Id-ul bucket list-ului. </param>
        /// <returns> Modelul de bucket list care a fost cautat sau un mesaj de eroare. </returns>
        [HttpGet("{bucketlistId}")]
        public async Task<IActionResult> Get([FromRoute] Guid bucketlistId)
        {
            var (_, isFailure, result, error) = await _bucketListService.Get(bucketlistId);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Ok(result);
        }

        /// <summary>
        /// Metoda expusa pe web care modifica starea activitatilor din bucket list.
        /// </summary>
        /// <param name="bucketlistId"> Id-ul bucket list-ului. </param>
        /// <param name="activityId"> Id-ul activitatii. </param>
        /// <returns> Un model de BucketList care a fost updatat sau un mesaj de eroare. </returns>
        [HttpPut("{bucketlistId}/activities")]
        public async Task<IActionResult> Change([FromRoute] Guid bucketlistId, [FromBody] BucketListUpdateModel updateModel)
        {
            var (_, isFailure, result, error) = await _bucketListService.UpdateBucketList(bucketlistId, updateModel);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Ok();
        }

        /// <summary>
        /// Metoda expusa pe web care atribuie o activitate unui bucketlist.
        /// </summary>
        /// <param name="bucketlistId"> Id-ul bucket list-ului. </param>
        /// <param name="activityId"> Id-ul activitatii. </param>
        /// <returns> Un model de BucketList care a fost updatat sau un mesaj de eroare. </returns>
        [HttpPost("{bucketlistId}/activities/{activityId}")]
        public async Task<IActionResult> Add([FromRoute] Guid bucketlistId, [FromRoute] Guid activityId)
        {
            var (_, isFailure, result, error) = await _bucketListService.Add(bucketlistId, activityId);
            if (isFailure)
            { 
                return BadRequest(error);
            }
            return Ok(result);
        }
    }
}
