using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Models.Activity;
using DoFest.Business.Activities.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace DoFest.API.Controllers
{
    [Route("/api/v1/activities")]
    [ApiController]
    [Authorize]
    public class ActivitiesController : ControllerBase
    {
        // ****** Servicii folosite de catre controller ******
        private readonly IActivitiesService _activitiesService;

        /// Constructorul public care va injecta serviciile necesare prin IoC
        public ActivitiesController(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        // ****** Maparea metodelor HTTP ******

        /// <summary>
        /// Metoda GetActivities expusa public pe web prin care se acceseaza toate activitatile din baza de date a aplicatiei.
        /// </summary>
        /// <returns> Un raspuns Http care semnaleaza o eroare sau statusul ok impreuna cu datele cerute prin request. </returns>
        [HttpGet("")]
        public async Task<IActionResult> GetActivities()
        {
            var (_, _, result, _) = await _activitiesService.GetActivityLists();
            return Ok(result);
        }

        [HttpGet("{activityId}")]
        public async Task<IActionResult> Get([FromRoute] Guid activityId)
        {
            var (_, isFailure, result, error) = await _activitiesService.Get(activityId);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] CreateActivityModel activity)
        {
            var (_, isFailure, result, error) = await _activitiesService.Add(activity);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Created(result.Id.ToString(), result);
        }

        [HttpDelete("{activityId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid activityId)
        {
            var(_, isFailure, result, error) = await _activitiesService.Delete(activityId);
            if (isFailure)
            {
                return BadRequest(error);
            }
            return Ok(result);
        }
    }
}
