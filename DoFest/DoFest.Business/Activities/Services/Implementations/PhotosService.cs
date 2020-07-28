using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using DoFest.Business.Activities.Models.Content.Photos;
using DoFest.Business.Activities.Services.Interfaces;
using DoFest.Entities.Activities.Content;
using DoFest.Persistence.Activities;
using Microsoft.AspNetCore.Http;

namespace DoFest.Business.Activities.Services.Implementations
{
    public sealed class PhotosService : IPhotosService
    {
        private readonly IMapper _mapper;
        private readonly IActivitiesRepository _repository;
        private readonly IHttpContextAccessor _accessor;      //ajuta la extragerea userId-ului

        public PhotosService(IActivitiesRepository repository, IMapper mapper, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _mapper = mapper;
            _accessor = accessor;
        }

        public async Task<IEnumerable<PhotoModel>> Get(Guid activityId)
        {

            var activity = await _repository.GetByIdWithPhotos(activityId);

            return _mapper.Map<IEnumerable<PhotoModel>>(activity.Photos);

        }

        public async Task<PhotoModel> Add(Guid activityId, CreatePhotoModel model)
        {
            //va fi folosit (impreuna cu [JsonIgnore] asupra campului UserId din model) pentru a extrage user-ul logat


            //model.UserId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);

            using var stream = new MemoryStream();
            await model.Image.CopyToAsync(stream);

            var photo = new Photo
            {
                Image = stream.ToArray()
            };


            var activity = await _repository.GetById(activityId);

            activity.AddPhoto(photo);
            _repository.Update(activity);

            await _repository.SaveChanges();

            return _mapper.Map<PhotoModel>(photo);
        }

        public async Task Delete(Guid activityId, Guid photoId)
        {
            var activity = await _repository.GetByIdWithPhotos(activityId);

            activity.RemovePhoto(photoId);
            _repository.Update(activity);

            await _repository.SaveChanges();
        }
    }
}
