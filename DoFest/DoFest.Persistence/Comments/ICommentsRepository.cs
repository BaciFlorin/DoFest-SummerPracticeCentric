using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Entities.Activities.Content;

namespace DoFest.Persistence.Comments
{
    /// <summary>
    /// Se ocupa de operatiile din baza de date din tabela Comment.
    /// </summary>
    public interface ICommentsRepository: IRepository<Comment>
    {
        /// <summary>
        /// Extrage din baza de date toate comentariile asociate unei activitati.
        /// </summary>
        /// <param name="activityId"> Id-ul unei activitati. </param>
        /// <returns> O lista de comentarii. </returns>
        Task<List<Comment>> GetComments(Guid activityId);

        /// <summary>
        /// Adauga un comentariu nou in tabela.
        /// </summary>
        /// <param name="comment"> Entitate comment ce urmeaza sa fie adaugata. </param>
        void AddComment(Comment comment);

        /// <summary>
        /// Sterge un comentariu dupa id-ul asociat.
        /// </summary>
        /// <param name="commentId"> Id-ul comentariului. </param>
        void DeleteComment(Guid commentId);
    }
}
