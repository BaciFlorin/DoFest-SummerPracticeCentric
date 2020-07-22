using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DoFest.Business.Models.Content.Comment;
using DoFest.Business.Services.Interfaces;
using DoFest.Persistence.Activities;

namespace DoFest.Business.Services.Implementations
{
    public sealed class CommentsService: ICommentsService
    {
        private readonly IMapper mapper;
        private readonly IActivitiesRepository _repository;
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
