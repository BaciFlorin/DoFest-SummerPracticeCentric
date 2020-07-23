using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DoFest.Business.Models.Content.Comment;
using DoFest.Business.Services.Interfaces;
using DoFest.Entities.Activities.Content;
using DoFest.Persistence.Activities;

namespace DoFest.Business.Services.Implementations
{
    /// <summary>
    /// Implementarea serviciului pentru comentarii.
    /// </summary>
    public sealed class CommentsService: ICommentsService
    {
        private readonly IMapper _mapper;
        private readonly IActivitiesRepository _repository;

        public CommentsService(IMapper mapper, IActivitiesRepository repository)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        public async Task<IList<CommentModel>> GetComments(Guid activityId)
        {
            // TODO: exception handle
            var comments = await _repository.GetByIdWithComments(activityId);

            return _mapper.Map<List<CommentModel>>(comments.Comments);
        }

        public async Task<CommentModel> AddComment(Guid activityId, NewCommentModel commentModel)
        {
            // TODO: exception handle
            var activity = await _repository.GetById(activityId);
            var comment = _mapper.Map<Comment>(commentModel);
            activity.AddComment(comment);
            _repository.Update(activity);
            await _repository.SaveChanges();
            return _mapper.Map<CommentModel>(comment);
        }

        public async Task<CommentModel> DeleteComment(Guid activityId, Guid commentId)
        {
            // TODO: exception handle

            var activity = await _repository.GetByIdWithComments(activityId);
            var comment = activity
                .Comments
                .FirstOrDefault(commentSearch => commentSearch.Id == commentId);
            try
            {
                activity.RemoveComment(commentId);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            _repository.Update(activity);
            await _repository.SaveChanges();

            return _mapper.Map<CommentModel>(comment);
        }
    }
}
