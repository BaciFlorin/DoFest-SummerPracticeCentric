using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Models.Content.Comment;
using DoFest.Business.Activities.Services.Interfaces;
using DoFest.Business.Errors;
using DoFest.Entities.Activities.Content;
using DoFest.Entities.Authentication.Notification;
using DoFest.Persistence.Activities;
using DoFest.Persistence.Authentication;
using Microsoft.AspNetCore.Http;

namespace DoFest.Business.Activities.Services.Implementations
{
    /// <summary>
    /// Implementarea serviciului pentru comentarii.
    /// </summary>
    public sealed class CommentsService : ICommentsService
    {
        private readonly IMapper _mapper;
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IHttpContextAccessor _accessor;
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Constructor public default.
        /// </summary>
        /// <param name="mapper"> Serviciul de mapare. </param>
        /// <param name="repository"> Repository-ul atribuit activitatilor. </param>
        /// <param name="accessor"> Un accesor pentru accesarea campurilor requestului HTTP. </param>
        public CommentsService(IMapper mapper, IActivitiesRepository activitiesRepository, IHttpContextAccessor accessor,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _activitiesRepository = activitiesRepository;
            _accessor = accessor;
            _userRepository = userRepository;
        }

        public async Task<Result<IList<CommentModel>, Error>> GetComments(Guid activityId)
        {
            var activityExists = (await _activitiesRepository.GetById(activityId)) != null;
            if (!activityExists)
            {
                return Result.Failure<IList<CommentModel>, Error>(ErrorsList.UnavailableActivity);
            }


            var comments = (await _activitiesRepository.GetByIdWithComments(activityId)).Comments;

            var commentsModel = new List<CommentModel>();

            foreach (var comment in comments)
            {
                var user = await _userRepository.GetById(comment.UserId);

                commentsModel.Add(CommentModel.Create(comment.Id, comment.ActivityId,
                    comment.UserId, user.Username, comment.Content));
            }

            return Result.Success<IList<CommentModel>, Error>(commentsModel);
        }

        public async Task<Result<CommentModel, Error>> AddComment(Guid activityId, NewCommentModel commentModel)
        {
            commentModel.UserId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var activity = await _activitiesRepository.GetById(activityId);
            if (activity == null)
            {
                return Result.Failure<CommentModel, Error>(ErrorsList.UnavailableActivity);
            }

            var comment = _mapper.Map<Comment>(commentModel);

            activity.AddComment(comment);

            var user = await _userRepository.GetById(commentModel.UserId);
            var notification = new Notification(activityId,
                                                DateTime.Now, 
                                                $" {user.Username} has added a comment to activity {activity.Name} : {comment.Content}."
                                                );

            activity.AddNotification(notification);

            _activitiesRepository.Update(activity);
            await _activitiesRepository.SaveChanges();

            return Result.Success<CommentModel, Error>(CommentModel.Create(comment.Id, comment.ActivityId,
                comment.UserId, user.Username, comment.Content));
        }

        public async Task<Result<CommentModel, Error>> DeleteComment(Guid activityId, Guid commentId)
        {
            var activityExists = (await _activitiesRepository.GetById(activityId)) != null;
            if (!activityExists)
            {
                return Result.Failure<CommentModel, Error>(ErrorsList.UnavailableActivity);
            }

            var activity = await _activitiesRepository.GetByIdWithComments(activityId);

            var comment = activity
                .Comments
                .FirstOrDefault(commentSearch => commentSearch.Id == commentId);
            if (comment == null)
            {
                return Result.Failure<CommentModel, Error>(ErrorsList.UnavailableComment);
            }

            activity.RemoveComment(commentId);

            _activitiesRepository.Update(activity);
            await _activitiesRepository.SaveChanges();


            return _mapper.Map<CommentModel>(comment);
        }
    }
}