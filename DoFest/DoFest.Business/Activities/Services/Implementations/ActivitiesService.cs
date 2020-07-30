using System;
using System.Threading.Tasks;
using AutoMapper;
using DoFest.Business.Activities.Models.Activity;
using DoFest.Business.Activities.Services.Interfaces;
using DoFest.Persistence.Activities;

namespace DoFest.Business.Activities.Services.Implementations
{
    public sealed class ActivitiesService : IActivitiesService
    {
        private readonly IMapper _mapper;
        private readonly IActivitiesRepository _repository;

        public ActivitiesService(IActivitiesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<ActivityModel> Get(Guid activityId)
        {

            var activity = await _repository.GetById(activityId);

            return _mapper.Map<ActivityModel>(activity);

        }
    }
}
