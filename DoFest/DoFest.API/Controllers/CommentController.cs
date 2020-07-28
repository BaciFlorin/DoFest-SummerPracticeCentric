using System;
using System.Threading.Tasks;
using DoFest.Business.Activities.Models.Content.Comment;
using DoFest.Business.Activities.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoFest.API.Controllers
{
    [Route("/api/v1/activities/{activityId}/comments/")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        // ****** Servicii folosite de catre controller ******
        private readonly ICommentsService _commentsService;

        /// Constructorul public care va injecta serviciile necesare prin IoC
        public CommentController(ICommentsService commentsService)
        {
            this._commentsService = commentsService;
        }

        // ****** Maparea metodelor HTTP ******

        /// <summary>
        /// Metoda GetActivities expusa public pe web prin care se acceseaza commentariile specifice unei activitati
        /// identificata prin activityId.
        /// </summary>
        /// <param name="activityId"> Guid-ul activitatii pentru care se face cautarea. Aceasta resursa asigura unicitatea. </param>
        /// <returns>Un raspuns Http care semnaleaza o eroare sau statusul ok impreuna cu datele(comentariile) cerute prin request.</returns>
        [HttpGet("")]
        public async Task<IActionResult> GetComments([FromRoute] Guid activityId)
        {
            var comments = await _commentsService.GetComments(activityId);
            return Ok(comments);
        }

        /// <summary>
        /// Metoda PostComment expusa public pe web prin care se pot adauga comentarii noi unei postari din baza de date.
        /// Activitatea se identifica prin id-ul atribuit acesteia.
        /// </summary>
        /// <param name="activityId"> Guid-ul activitatii pentru care se face cautarea. Aceasta resursa asigura unicitatea. </param>
        /// <param name="model"> Un model de data ce reprezinta commentariul ce urmeaza sa fie adaugat.</param>
        /// <returns> Un raspuns Http care semnaleaza o eroare sau statusul ok impreuna cu un mesaj de confirmare. </returns>
        [HttpPost("")]
        public async Task<IActionResult> PostComment([FromRoute] Guid activityId, [FromBody] NewCommentModel model)
        {
            var newComment = await _commentsService.AddComment(activityId, model);
            return Ok(newComment);
        }

        /// <summary>
        /// Metoda DeleteComment expusa public pe web prin care se pot sterge comentarii asociate unei postari din baza de date.
        /// Resursele se identifica printr-un id asociat unic.
        /// </summary>
        /// <param name="activityId"> Guid-ul activitatii pentru care se face cautarea. Aceasta resursa asigura unicitatea. </param>
        /// <param name="commentId"> Guid-ul commentariu pentru care se face cautarea. Aceasta resursa asigura unicitatea. </param>
        /// <returns> Un raspuns Http care semnaleaza o eroare sau statusul ok impreuna cu un mesaj de confirmare. </returns>
        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteComment([FromRoute] Guid activityId, [FromRoute] Guid commentId)
        {
            var comment = await _commentsService.DeleteComment(activityId, commentId);

            return Ok(comment);
        }
    }
}
