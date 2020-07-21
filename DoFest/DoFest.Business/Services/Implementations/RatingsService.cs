using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DoFest.Business.Models.Ratings;
using DoFest.Business.Services.Interfaces;
using DoFest.Persistence.Activities;
using Microsoft.AspNetCore.Http;

namespace DoFest.Business.Services.Implementations
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
            throw new NotImplementedException();
        }

        public async Task<RatingModel> Add(Guid activityId, CreateRatingModel model)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid activityId, Guid ratingId)
        {
            throw new NotImplementedException();
        }
    }
}
