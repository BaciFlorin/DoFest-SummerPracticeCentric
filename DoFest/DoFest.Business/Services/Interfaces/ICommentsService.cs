using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Business.Models.Content.Comment;

namespace DoFest.Business.Services.Interfaces
{
    /// <summary>
    /// Definirea contractul folosit de catre un serviciu de comentarii.
    /// </summary>
    public interface ICommentsService
    {
        /// <summary>
        /// Metoda ce returneaza toate comentariile asociate unei activitati.
        /// </summary>
        /// <param name="activityId"> Id-ul activitatii cautate. </param>
        /// <returns> O lista cu toate comentariile unei activitati. </returns>
        Task<IList<CommentModel>> GetComments(Guid activityId);

        /// <summary>
        /// Metoda de adaugare a unui comentariu.
        /// </summary>
        /// <param name="activityId"> Id-ul activitatii careia ii va fi adaugat comentariul. </param>
        /// <param name="commentModel"> Modelul business atribuit comentariului ce va fi adaugat. </param>
        /// <returns> Un model business cu comentariul adaugat. </returns>
        /// TODO: schimba datele returnate
        Task<CommentModel> AddComment(Guid activityId, NewCommentModel commentModel);

        /// <summary>
        /// Metoda de delete a unui comentariu existent in db.
        /// </summary>
        /// <param name="activityId"> Id-ul activitatii careia este asociat comentariul. </param>
        /// <param name="commentId"> Id-ul cometariului care urmeaza sa fie sters. </param>
        /// <returns> Un model business cu comentariul sters. </returns>
        /// TODO: schimba datele returnate
        Task<CommentModel> DeleteComment(Guid activityId, Guid commentId);
    }
}
