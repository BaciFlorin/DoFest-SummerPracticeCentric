using System;
using System.Linq;
using DoFest.Entities.Activities.Content;

namespace DoFest.Persistence.Comments
{
    public interface ICommentsRepository: IRepository<Comment>
    {
        IQueryable<Comment> GetComments(Guid activityId);

        void AddComment(Comment comment);

        void DeleteComment(Guid commentId);
    }
}
