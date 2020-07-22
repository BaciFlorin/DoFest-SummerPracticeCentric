using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Business.Models.Content.Ratings;

namespace DoFest.Business.Services.Interfaces
{
    public interface IRatingsService
    {
        Task<IEnumerable<RatingModel>> Get(Guid activityId);

        Task<RatingModel> Add(Guid activityId, CreateRatingModel model);

        Task Delete(Guid activityId, Guid ratingId);

    }
}
