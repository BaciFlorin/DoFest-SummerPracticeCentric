using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DoFest.Business.Activities.Models.Content.Ratings;
using DoFest.Business.Activities.Services.Interfaces;
using DoFest.Entities.Activities.Content;
using DoFest.Persistence.Activities;
using Microsoft.AspNetCore.Http;

namespace DoFest.Business.Activities.Services.Implementations
{
    public class RatingsService : IRatingsService
    {

        private readonly IMapper _mapper;
        private readonly IActivitiesRepository _repository;
        private readonly IHttpContextAccessor _accessor;

        public RatingsService(IMapper mapper, IActivitiesRepository repository, IHttpContextAccessor accessor)
        {
            _mapper = mapper;
            _repository = repository;
            _accessor = accessor;
        }
        public async Task<IEnumerable<RatingModel>> Get(Guid activityId)
        {
            var activity = await _repository.GetByIdWithRatings(activityId);

            return _mapper.Map<IEnumerable<RatingModel>>(activity.Ratings);
        }

        public async Task<RatingModel> Add(Guid activityId, CreateRatingModel model)
        {
            model.UserId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);

            var activity = await _repository.GetById(activityId);
            var rating = _mapper.Map<Rating>(model);

            activity.AddRating(rating);

            _repository.Update(activity);

            await _repository.SaveChanges();

            return _mapper.Map<RatingModel>(rating);
        }

        public async Task Delete(Guid activityId, Guid ratingId)
        {
            var activity = await _repository.GetByIdWithRatings(activityId);

            activity.RemoveRating(activityId);

            _repository.Update(activity);

            await _repository.SaveChanges();
        }
    }
}
