using DoFest.Business.Services.Interfaces;
using DoFest.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DoFest.Business.Models.Activity;
using DoFest.Persistence.Activities;
using DoFest.Business.Activities.Services.Interfaces;

namespace DoFest.API.Controllers
{
    [Route("/api/v1/activities")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {

        // ****** Servicii folosite de catre controller ******
        private readonly IActivitiesService _activitiesService;
        private readonly IActivityTypeService _activityTypeService;

        /// Constructorul public care va injecta serviciile necesare prin IoC
        public ActivitiesController(IActivitiesService activitiesService, IActivityTypeService activityTypeService)
        {
            _activitiesService = activitiesService;
            _activityTypeService = activityTypeService;
        }

        // ****** Maparea metodelor HTTP ******

        /// <summary>
        /// Metoda GetActivities expusa public pe web prin care se acceseaza toate activitatile din baza de date a aplicatiei.
        /// </summary>
        /// <returns> Un raspuns Http care semnaleaza o eroare sau statusul ok impreuna cu datele cerute prin request. </returns>
        [HttpGet("")]
        public async Task<IActionResult> GetActivities()
        {
            var result = await _activitiesService.GetActivityLists();

            return Ok(result);
        }

        [HttpGet("{activityId}")]
        // TODO: adaugarea logicii business
        public async Task<IActionResult> Get([FromRoute] Guid activityId)
        {
            var result = await _activitiesService.Get(activityId);

            return Ok(result);
        }

        [HttpPost("")]

        // TODO: adaugarea logicii business
        public async Task<IActionResult> Add([FromBody] CreateActivityModel activity)
        {
            var result = await _activitiesService.Add(activity);

            return Ok(result);
        }

        [HttpDelete("{activityId}")]

        // TODO: adaugarea logicii business
        public async Task<IActionResult> Delete([FromRoute] Guid activityId)
        {
            await _activitiesService.Delete(activityId);

            return NoContent();
        }

        [HttpGet("allTypes")]
        public async Task<IActionResult> GetActivityTypeList()
        {
            var result = await _activityTypeService.GetActivitiesType();

            return Ok(result);
        }
    }
}
