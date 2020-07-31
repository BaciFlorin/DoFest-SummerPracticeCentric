using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Business.Activities.Models.Content.Ratings;

namespace DoFest.Business.Activities.Services.Interfaces
{
    public interface IRatingsService
    {
        Task<IEnumerable<RatingModel>> Get(Guid activityId);

        Task<RatingModel> Add(Guid activityId, CreateRatingModel model);

        Task Delete(Guid activityId, Guid ratingId);

        Task<RatingModel> Update(Guid activityId, Guid ratingId, CreateRatingModel model);

    }
}
