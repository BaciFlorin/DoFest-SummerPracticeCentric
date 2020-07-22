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
        /// Selecteaza si returneaza toate comentariile asociate unei activitati din baza de date.
        /// </summary>
        /// <param name="activityId"> Id-ul unei activitati. </param>
        /// <returns> Un enumerabil ce contine toate comentariile asociate unei activitati. </returns>
        IEnumerable<CommentModel> GetComments(Guid activityId);

        /// <summary>
        /// Adauga un comentariu la o activitate specificata.
        /// </summary>
        /// <param name="commentModel"> Un model de comentariu nou. </param>
        /// <returns> ??? Un string ce semnifica succesul/esecul operatiei. </returns>
        CommentModel AddComment(NewCommentModel commentModel);

        /// <summary>
        /// Sterge un comentariu asociat unei activitati.
        /// </summary>
        /// <param name="commentId"> Id-ul unui comentariu. </param>
        /// <returns> ??? Un string ce semnifica succesul/esecul operatiei. </returns>
        Task<CommentModel> DeleteComment(Guid commentId);
    }
}
