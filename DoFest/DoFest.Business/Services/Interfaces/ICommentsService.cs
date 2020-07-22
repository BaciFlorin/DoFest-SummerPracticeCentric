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
        Task<IEnumerable<CommentModel>> GetComments(Guid activityId);

        /// <summary>
        /// Adauga un comentariu la o activitate specificata.
        /// </summary>
        /// <param name="activityId"> Id-ul unei activitati. </param>
        /// <returns> ??? Un string ce semnifica succesul/esecul operatiei. </returns>
        Task AddComment(Guid activityId);

        /// <summary>
        /// Sterge un comentariu asociat unei activitati.
        /// </summary>
        /// <param name="activityId"> Id-ul unei activitati. </param>
        /// <returns> ??? Un string ce semnifica succesul/esecul operatiei. </returns>
        Task DeleteComment(Guid activityId);
    }
}
