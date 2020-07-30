using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DoFest.Business.Models.Photos;
using DoFest.Business.Services.Interfaces;
using DoFest.Entities.Activities.Content;
using DoFest.Persistence.Activities;
using Microsoft.AspNetCore.Http;

namespace DoFest.Business.Services.Implementations
{
    public sealed class PhotosService : IPhotosService
    {
        private readonly IMapper mapper;
        private readonly IActivitiesRepository repository;
        private readonly IHttpContextAccessor accessor;

        public PhotosService(IActivitiesRepository repository, IMapper mapper, IHttpContextAccessor accessor)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.accessor = accessor;
        }

        public async Task<IEnumerable<PhotoModel>> Get(Guid activityId)
        {

            var activity = await this.repository.GetByIdWithPhotos(activityId);

            return this.mapper.Map<IEnumerable<PhotoModel>>(activity.Photos);

        }

        public async Task<PhotoModel> Add(Guid activityId, CreatePhotoModel model)
        {

            model.UserId = Guid.Parse(this.accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);

            using var stream = new MemoryStream();
            await model.Image.CopyToAsync(stream);

            var photo = new Photo
            {
                Image = stream.ToArray()
            };


            var activity = await this.repository.GetById(activityId);

            activity.AddPhoto(photo);
            this.repository.Update(activity);

            await this.repository.SaveChanges();

            return this.mapper.Map<PhotoModel>(photo);
        }

        public async Task Delete(Guid activityId, Guid photoId)
        {
            var activity = await this.repository.GetByIdWithPhotos(activityId);

            activity.RemovePhoto(photoId);
            this.repository.Update(activity);

            await this.repository.SaveChanges();
        }
    }
}
