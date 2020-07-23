using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DoFest.Business.Models.Content.Comment;
using DoFest.Business.Services.Interfaces;
using DoFest.Entities.Activities.Content;
using DoFest.Persistence.Comments;

namespace DoFest.Business.Services.Implementations
{
    /// <summary>
    /// Implementarea serviciului pentru comentarii.
    /// </summary>
    public sealed class CommentsService: ICommentsService
    {
        private readonly IMapper _mapper;
        private readonly ICommentsRepository _repository;

        public CommentsService(IMapper mapper, ICommentsRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        public async Task<List<CommentModel>> GetComments(Guid activityId)
        {
            var comments = await _repository.GetComments(activityId);

            return _mapper.Map<List<CommentModel>>(comments);
        }

        public CommentModel AddComment(NewCommentModel commentModel)
        {
            var comment = _mapper.Map<Comment>(commentModel);
            _repository.AddComment(comment);


            return _mapper.Map<CommentModel>(comment);
        }

        public async Task<CommentModel> DeleteComment(Guid commentId)
        {
            var comment = await _repository.GetById(commentId);
            _repository.DeleteComment(commentId);

            return _mapper.Map<CommentModel>(comment);
        }
    }
}
