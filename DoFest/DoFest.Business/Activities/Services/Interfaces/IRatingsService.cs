using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Models.Content.Ratings;
using DoFest.Business.Errors;

namespace DoFest.Business.Activities.Services.Interfaces
{
    public interface IRatingsService
    {
        Task<Result<IEnumerable<RatingModel>, Error>> Get(Guid activityId);

        Task<Result<RatingModel, Error>> Add(Guid activityId, CreateRatingModel model);

        Task<Result<string, Error>> Delete(Guid activityId, Guid ratingId);

        Task<Result<RatingModel, Error>> Update(Guid activityId, Guid ratingId, CreateRatingModel model);

    }
}
