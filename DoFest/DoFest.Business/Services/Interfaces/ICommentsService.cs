using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Business.Models.Content.Comment;

namespace DoFest.Business.Services.Interfaces
{
    public interface ICommentsService
    {
        Task<IEnumerable<CommentModel>> GetComments(Guid activityId);

        Task AddComment(Guid activityId);

        Task DeleteComment(Guid activityId);
    }
}
