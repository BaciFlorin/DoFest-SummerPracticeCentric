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
using DoFest.Persistence.Activities;
using Microsoft.AspNetCore.Http;

namespace DoFest.Business.Activities.Services.Implementations
{
    public sealed class PhotosService : IPhotosService
    {
        private readonly IMapper _mapper;
        private readonly IActivitiesRepository _repository;
        private readonly IHttpContextAccessor _accessor;      

        public PhotosService(IActivitiesRepository repository, IMapper mapper, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _mapper = mapper;
            _accessor = accessor;
        }

        public async Task<Result<IEnumerable<PhotoModel>, Error>> Get(Guid activityId)
        {
            var activityExists = (await _repository.GetById(activityId)) != null;
            if (!activityExists)
            {
                return Result.Failure<IEnumerable<PhotoModel>, Error>(ErrorsList.UnavailableActivity);
            }

            var activity = await _repository.GetByIdWithPhotos(activityId);

            return Result.Success<IEnumerable<PhotoModel>, Error>(_mapper.Map<IEnumerable<PhotoModel>>(activity.Photos));

        }

        public async Task<Result<PhotoModel, Error>> Add(Guid activityId, CreatePhotoModel model)
        {
            model.UserId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);

            using var stream = new MemoryStream();
            await model.Image.CopyToAsync(stream);

            var photo = new Photo
            {
                Image = stream.ToArray()
            };

            var activity = await _repository.GetById(activityId);
            if (activity == null)
            {
                return Result.Failure<PhotoModel, Error>(ErrorsList.UnavailableActivity);
            }

            activity.AddPhoto(photo);
            _repository.Update(activity);

            await _repository.SaveChanges();

            return Result.Success<PhotoModel, Error>(_mapper.Map<PhotoModel>(photo));
        }

        public async Task<Result<string, Error>> Delete(Guid activityId, Guid photoId)
        {
            var activity = await _repository.GetByIdWithPhotos(activityId);
            if (activity == null)
            {
                return Result.Failure<string, Error>(ErrorsList.UnavailableActivity);
            }
            var photo = activity.Photos.FirstOrDefault(p => p.Id == photoId);

            if (photo == null)
            {
                return Result.Failure<string, Error>(ErrorsList.InvalidPhoto);
            }

            var loggedUserId = Guid.Parse(this._accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            if (loggedUserId != photo.UserId)
            {
                return Result.Failure<string, Error>(ErrorsList.DeleteNotAuthorized);
            }

            activity.RemovePhoto(photoId);
            _repository.Update(activity);

            await _repository.SaveChanges();

            return Result.Success<string, Error>("Photo deleted successfully");
        }
    }
}
