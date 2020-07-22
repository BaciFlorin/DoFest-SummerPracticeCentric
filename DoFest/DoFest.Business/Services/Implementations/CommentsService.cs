using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DoFest.Business.Models.Content.Comment;
using DoFest.Business.Services.Interfaces;
using DoFest.Entities.Activities.Content;
using DoFest.Persistence.Comments;
using Microsoft.EntityFrameworkCore;

namespace DoFest.Business.Services.Implementations
{
    public sealed class CommentsService: ICommentsService
    {
        private readonly IMapper mapper;
        private readonly ICommentsRepository repository;

        public CommentsService(IMapper mapper, ICommentsRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<CommentModel> GetComments(Guid activityId)
        {
            var comments = repository.GetComments(activityId);
            var result = await comments.FirstAsync();


            return mapper.Map<CommentModel>(result);
        }

        public CommentModel AddComment(NewCommentModel commentModel)
        {
            var comment = mapper.Map<Comment>(commentModel);
            repository.AddComment(comment);


            return mapper.Map<CommentModel>(comment);
        }

        public async Task<CommentModel> DeleteComment(Guid commentId)
        {
            var comment = await repository.GetById(commentId);
            repository.DeleteComment(commentId);

            return mapper.Map<CommentModel>(comment);
        }
    }
}
