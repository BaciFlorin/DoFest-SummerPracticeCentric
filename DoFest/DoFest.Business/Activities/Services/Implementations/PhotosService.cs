using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Models.Content.Photos;
using DoFest.Business.Activities.Services.Interfaces;
using DoFest.Business.Errors;
using DoFest.Entities.Activities.Content;
using DoFest.Entities.Authentication.Notification;
using DoFest.Persistence.Activities;
using DoFest.Persistence.Authentication;
using Microsoft.AspNetCore.Http;

namespace DoFest.Business.Activities.Services.Implementations
{
    public sealed class PhotosService : IPhotosService
    {
        private readonly IMapper _mapper;
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IHttpContextAccessor _accessor;
        private readonly IUserRepository _userRepository;

        public PhotosService(IActivitiesRepository activitiesRepository, IMapper mapper, IHttpContextAccessor accessor,
            IUserRepository userRepository)
        {
            _activitiesRepository = activitiesRepository;
            _mapper = mapper;
            _accessor = accessor;
            _userRepository = userRepository;
        }

        public async Task<Result<IEnumerable<PhotoModel>, Error>> Get(Guid activityId)
        {
            var activityExists = (await _activitiesRepository.GetById(activityId)) != null;
            if (!activityExists)
            {
                return Result.Failure<IEnumerable<PhotoModel>, Error>(ErrorsList.UnavailableActivity);
            }

            var activity = await _activitiesRepository.GetByIdWithPhotos(activityId);

            var photos = activity.Photos;

            var photosModel = new List<PhotoModel>();

            foreach (var photo in photos)
            {
                var user = await _userRepository.GetById(photo.UserId);

                photosModel.Add(PhotoModel.Create(photo.Id, photo.ActivityId,
                    photo.UserId, user.Username, photo.Image));
            }

            return Result.Success<IEnumerable<PhotoModel>, Error>(photosModel);

        }

        public async Task<Result<PhotoModel, Error>> Add(Guid activityId, CreatePhotoModel model)
        {
            model.UserId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);

            using var stream = new MemoryStream();
            await model.Image.CopyToAsync(stream);

            var activity = await _activitiesRepository.GetById(activityId);
            if (activity == null)
            {
                return Result.Failure<PhotoModel, Error>(ErrorsList.UnavailableActivity);
            }

            var photo = new Photo(activityId, model.UserId, stream.ToArray());
            activity.AddPhoto(photo);

            var user = await _userRepository.GetById(photo.UserId);

            var notification = new Notification(activityId, 
                                                DateTime.Now, 
                                                $"{user.Username} has added a new photo to activity {activity.Name}."
                                                );

            activity.AddNotification(notification);

            _activitiesRepository.Update(activity);

            await _activitiesRepository.SaveChanges();

            return Result.Success<PhotoModel, Error>(PhotoModel.Create(
                photo.Id, photo.ActivityId, photo.UserId, user.Username, photo.Image));
        }

        public async Task<Result<string, Error>> Delete(Guid activityId, Guid photoId)
        {
            var activityExists = (await _activitiesRepository.GetById(activityId)) != null;
            if (!activityExists)
            {
                return Result.Failure<string, Error>(ErrorsList.UnavailableActivity);
            }

            var activity = await _activitiesRepository.GetByIdWithPhotos(activityId);

            var photo = activity.Photos.FirstOrDefault(p => p.Id == photoId);

            if (photo == null)
            {
                return Result.Failure<string, Error>(ErrorsList.UnavailablePhoto);
            }

            var loggedUserId = Guid.Parse(this._accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            if (loggedUserId != photo.UserId)
            {
                return Result.Failure<string, Error>(ErrorsList.DeleteNotAuthorized);
            }

            activity.RemovePhoto(photoId);
            _activitiesRepository.Update(activity);

            await _activitiesRepository.SaveChanges();

            return Result.Success<string, Error>("Photo deleted successfully");
        }
    }
}