using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Business.Models.Photos;

namespace DoFest.Business.Services.Interfaces
{
    public interface IPhotosService
    {
        Task<IEnumerable<PhotoModel>> Get(Guid activityId);

        Task<PhotoModel> Add(Guid activityId, CreatePhotoModel model);

        Task Delete(Guid activityId, Guid photoId);

    }
}
