using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DoFest.Business.Models.Ratings;
using DoFest.Business.Services.Interfaces;
using DoFest.Entities.Activities.Content;
using DoFest.Persistence.Activities;
using Microsoft.AspNetCore.Http;

namespace DoFest.Business.Services.Implementations
{
    public class RatingsService : IRatingsService
    {

        private readonly IMapper mapper;
        private readonly IActivitiesRepository repository;
        private readonly IHttpContextAccessor accessor;

        public RatingsService(IMapper mapper, IActivitiesRepository repository, IHttpContextAccessor accessor)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.accessor = accessor;
        }

        public async Task<IEnumerable<RatingModel>> Get(Guid activityId)
        {
            var activity = await this.repository.GetByIdWithRatings(activityId);

            return this.mapper.Map<IEnumerable<RatingModel>>(activity.Ratings);
        }

        public async Task<RatingModel> Add(Guid activityId, CreateRatingModel model)
        {

            model.UserId = Guid.Parse(this.accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);

            var activity = await this.repository.GetById(activityId);
            var rating = this.mapper.Map<Rating>(model);

            activity.AddRating(rating);

            this.repository.Update(activity);

            await this.repository.SaveChanges();

            return this.mapper.Map<RatingModel>(rating);
        }

        public async Task Delete(Guid activityId, Guid ratingId)
        {
            var activity = await this.repository.GetByIdWithRatings(activityId);

            activity.RemoveRating(ratingId);

            this.repository.Update(activity);

            await this.repository.SaveChanges();
        }

        public async Task<RatingModel> Update(Guid activityId, Guid ratingId, CreateRatingModel model)
        {
            var activity = await this.repository.GetByIdWithRatings(activityId);

            model.UserId = Guid.Parse(this.accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);

            var rating = activity.Ratings.FirstOrDefault(r => r.Id == ratingId);

            if (rating == null || model.UserId != rating.UserId) return null;
            rating.Stars = model.Stars;

            this.repository.Update(activity);

            await this.repository.SaveChanges();
            return this.mapper.Map<RatingModel>(rating);

        }
    }
}
