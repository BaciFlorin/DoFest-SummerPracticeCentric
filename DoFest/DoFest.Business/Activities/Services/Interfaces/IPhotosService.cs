using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Models.Content.Photos;
using DoFest.Business.Errors;

namespace DoFest.Business.Activities.Services.Interfaces
{
    public interface IPhotosService
    {
        Task<Result<IEnumerable<PhotoModel>, Error>> Get(Guid activityId);

        Task<Result<PhotoModel, Error>> Add(Guid activityId, CreatePhotoModel model);

        Task<Result<string, Error>> Delete(Guid activityId, Guid photoId);

    }
}
