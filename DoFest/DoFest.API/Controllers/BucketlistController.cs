using Microsoft.AspNetCore.Mvc;

namespace DoFest.API.Controllers
{
    [Route("api/v1/bucketlists")]
    [ApiController]
    public class BucketlistController : ControllerBase
    {
        // ****** Servicii folosite de catre controller ******
        //.........
        // TODO: adaugarea serviciilor


        /// Constructorul public care va injecta serviciile necesare prin IoC
        public BucketlistController()
        {
            // TODO
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
            // TODO: adaugarea sintaxei pentru async/await
            return Ok("Message from GetBucketLists." +
                      "\n[route: GET /api/v1/bucketlists]");
        }

    }
}
