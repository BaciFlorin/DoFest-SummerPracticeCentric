using System;
using DoFest.Business.Models.Content.Comment;
using Microsoft.AspNetCore.Mvc;

namespace DoFest.API.Controllers
{
    [Route("api/v1/activities")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        // ****** Servicii folosite de catre controller ******
        //.........
        // TODO: adaugarea serviciilor


        /// Constructorul public care va injecta serviciile necesare prin IoC
        public CommentController()
        {
            // TODO
        }

        // ****** Maparea metodelor HTTP ******

        /// <summary>
        /// Metoda GetActivities expusa public pe web prin care se acceseaza commentariile specifice unei activitati
        /// identificata prin activityId.
        /// </summary>
        /// <param name="activityId"> Guid-ul activitatii pentru care se face cautarea. Aceasta resursa asigura unicitatea. </param>
        /// <returns>Un raspuns Http care semnaleaza o eroare sau statusul ok impreuna cu datele(comentariile) cerute prin request.</returns>
        [HttpGet("/{activityId}/comments")]
        public IActionResult GetComments([FromRoute] Guid activityId)
        {
            // TODO: adaugarea logicii business
            // TODO: adaugarea sintaxei pentru async/await
            return Ok("Message from GetComments." +
                      $"\n[route: GET /api/v1/activities/{activityId}/comments]"
                      );
        }

        /// <summary>
        /// Metoda PostComment expusa public pe web prin care se pot adauga comentarii noi unei postari din baza de date.
        /// Activitatea se identifica prin id-ul atribuit acesteia.
        /// </summary>
        /// <param name="activityId"> Guid-ul activitatii pentru care se face cautarea. Aceasta resursa asigura unicitatea. </param>
        /// <param name="model"> Un model de data ce reprezinta commentariul ce urmeaza sa fie adaugat.</param>
        /// <returns> Un raspuns Http care semnaleaza o eroare sau statusul ok impreuna cu un mesaj de confirmare. </returns>
        [HttpPost("/{activityId}/comments")]
        public IActionResult PostComment([FromRoute] Guid activityId, [FromBody] NewCommentModel model)
        {
            // TODO: adaugarea logicii business
            // TODO: adaugarea sintaxei pentru async/await
            return Ok("Message from PostComment." +
                      $"\n[route: POST /api/v1/activities/{activityId}/comments]" +
                      $"\n comment:{model.Content}"
                      );
        }

        /// <summary>
        /// Metoda DeleteComment expusa public pe web prin care se pot sterge comentarii asociate unei postari din baza de date.
        /// Resursele se identifica printr-un id asociat unic.
        /// </summary>
        /// <param name="activityId"> Guid-ul activitatii pentru care se face cautarea. Aceasta resursa asigura unicitatea. </param>
        /// <param name="commentId"> Guid-ul commentariu pentru care se face cautarea. Aceasta resursa asigura unicitatea. </param>
        /// <returns> Un raspuns Http care semnaleaza o eroare sau statusul ok impreuna cu un mesaj de confirmare. </returns>
        [HttpDelete("/{activityId}/comments/{commentId}")]
        public IActionResult DeleteComment([FromRoute] Guid activityId, [FromRoute] Guid commentId)
        {
            // TODO: adaugarea logicii business
            // TODO: adaugarea sintaxei pentru async/await
            return Ok("Message from DeleteComment." +
                      $"\n[route DELETE /api/v1/activities/{activityId}/comments/{commentId}]"
                      );
        }
    }
}
