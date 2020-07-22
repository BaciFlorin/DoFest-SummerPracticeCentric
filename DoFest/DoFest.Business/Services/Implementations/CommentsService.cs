using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Business.Models.Content.Comment;
using DoFest.Business.Services.Interfaces;

namespace DoFest.Business.Services.Implementations
{
    public sealed class CommentsService: ICommentsService
    {
        public Task<IEnumerable<CommentModel>> GetComments(Guid activityId)
        {
            throw new NotImplementedException();
        }

        public Task AddComment(Guid activityId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteComment(Guid activityId)
        {
            throw new NotImplementedException();
        }
    }
}
