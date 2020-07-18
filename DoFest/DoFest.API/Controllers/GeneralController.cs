using Microsoft.AspNetCore.Mvc;

namespace DoFest.API.Controllers
{
    [Route("api/v1/info")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        // ****** Servicii folosite de catre controller
        //.........
        // TODO: adaugarea serviciilor


        /// Constructorul public care va injecta serviciile necesare prin IoC
        public GeneralController()
        {
            // TODO
        }

        // ****** Maparea metodelor HTTP

        /// <summary>
        /// Metoda GetBucketLists expusa public pe web prin care se acceseaza toate BucketList-urile utilizatorilor.
        /// </summary>
        /// <returns> Un raspuns Http care semnaleaza o eroare sau statusul ok impreuna cu datele cerute prin request. </returns>
        [HttpGet("/bucketlists")]
        public IActionResult GetBucketLists()
        {
            // TODO: adaugarea logicii business
            // TODO: adaugarea sintaxei pentru async/await
            return Ok("Message from GetBucketLists.");
        }

        /// <summary>
        /// Metoda GetActivities expusa public pe web prin care se acceseaza toate activitatile din baza de date a aplicatiei.
        /// </summary>
        /// <returns> Un raspuns Http care semnaleaza o eroare sau statusul ok impreuna cu datele cerute prin request. </returns>
        [HttpGet("/activities")]
        public IActionResult GetActivities()
        {
            // TODO: adaugarea logicii business
            // TODO: adaugarea sintaxei pentru async/await
            return Ok("Message from GetActivities.");
        }

    }
}
