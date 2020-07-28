using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DoFest.Business.Activities.Services.Interfaces;

namespace DoFest.API.Controllers
{
    [Route("api/v1/activities")]
    [ApiController]
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
        public IActionResult GetActivities()
        {
            // TODO: adaugarea logicii business
            // TODO: adaugarea sintaxei pentru async/await
            return Ok("Message from GetActivities." +
                      "\n[route: GET /api/v1/activities]");
            //retureneaza toate activitatile 
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
        public async Task<IActionResult> Add([FromRoute] Guid activityId)
        {
            var result = await _activitiesService.Get(activityId);

            return Ok(result);
        }

        [HttpDelete("/{activityId}")]

        // TODO: adaugarea logicii business
        public async Task<IActionResult> Delete([FromRoute] Guid activityId)
        {
            var result = await _activitiesService.Get(activityId);

            return Ok(result);
        }
    }
}
