using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Models.Content.Ratings;
using DoFest.Business.Activities.Services.Interfaces;
using DoFest.Business.Errors;
using DoFest.Entities.Activities.Content;
using DoFest.Entities.Authentication.Notification;
using DoFest.Persistence.Activities;
using DoFest.Persistence.Authentication;
using DoFest.Persistence.Notifications;
using Microsoft.AspNetCore.Http;

namespace DoFest.Business.Activities.Services.Implementations
{
    public class RatingsService : IRatingsService
    {

        private readonly IMapper _mapper;
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IHttpContextAccessor _accessor;
        private readonly INotificationRepository _notificationRepository;
        private readonly IUserRepository _userRepository;

        public RatingsService(IMapper mapper, IActivitiesRepository activitiesRepository, IHttpContextAccessor accessor,
            INotificationRepository notificationRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _activitiesRepository = activitiesRepository;
            _accessor = accessor;
            _notificationRepository = notificationRepository;
            _userRepository = userRepository;
        }
        public async Task<Result<IEnumerable<RatingModel>, Error>> Get(Guid activityId)
        {
            var activityExists = (await _activitiesRepository.GetById(activityId)) != null;
            if (!activityExists)
            {
                return Result.Failure<IEnumerable<RatingModel>, Error>(ErrorsList.UnavailableActivity);
            }

            var activity = await _activitiesRepository.GetByIdWithRatings(activityId);

            return Result.Success<IEnumerable<RatingModel>, Error>(
                _mapper.Map<IEnumerable<RatingModel>>(activity.Ratings));
        }

        public async Task<Result<RatingModel, Error>> Add(Guid activityId, CreateRatingModel model)
        {

            model.UserId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);

            var activity = await _activitiesRepository.GetById(activityId);

            if (activity == null)
            {
                return Result.Failure<RatingModel, Error>(ErrorsList.UnavailableActivity);
            }

            var rating = _mapper.Map<Rating>(model);

            activity.AddRating(rating);

            _activitiesRepository.Update(activity);

            await _activitiesRepository.SaveChanges();

            var user = await _userRepository.GetById(rating.UserId);
            var notification = new Notification()
            {
                ActivityId = activityId,
                Date = DateTime.Now,
                Description = $"{user.Username} has rated activity {activity.Name} with {rating.Stars} stars."
            };

            await _notificationRepository.Add(notification);
            await _notificationRepository.SaveChanges();

            return Result.Success<RatingModel, Error>(_mapper.Map<RatingModel>(rating));
        }

        public async Task<Result<string, Error>> Delete(Guid activityId, Guid ratingId)
        {
            var activity = await _activitiesRepository.GetByIdWithRatings(activityId);

            if (activity == null)
            {
                return Result.Failure<string, Error>(ErrorsList.UnavailableActivity);
            }

            var rating = activity.Ratings.FirstOrDefault(r => r.Id == ratingId) ;

            if (rating == null)
            {
                return Result.Failure<string, Error>(ErrorsList.UnavailableRating);
            }

            var loggedUserId = Guid.Parse(this._accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            if (loggedUserId != rating.UserId)
            {
                return Result.Failure<string, Error>(ErrorsList.DeleteNotAuthorized);
            }

            activity.RemoveRating(ratingId);

            _activitiesRepository.Update(activity);
            await _activitiesRepository.SaveChanges();

            return Result.Success<string, Error>("Rating deleted successfully");
        }

        public async Task<Result<RatingModel, Error>> Update(Guid activityId, Guid ratingId, CreateRatingModel model)
        {
            var activity = await this._activitiesRepository.GetByIdWithRatings(activityId);
            if (activity == null)
            {
                return Result.Failure<RatingModel, Error>(ErrorsList.UnavailableActivity);
            }

            model.UserId = Guid.Parse(this._accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);

            var rating = activity.Ratings.FirstOrDefault(r => r.Id == ratingId);

            if (rating == null)
            {
                return Result.Failure<RatingModel, Error>(ErrorsList.UnavailableRating);
            }

            if (model.UserId != rating.UserId)
            {
                return Result.Failure<RatingModel, Error>(ErrorsList.UpdateNotAuthorized);
            }

            rating.Stars = model.Stars;

            this._activitiesRepository.Update(activity);
            await this._activitiesRepository.SaveChanges();

            return Result.Success<RatingModel, Error>(this._mapper.Map<RatingModel>(rating));
        }
    }
}
