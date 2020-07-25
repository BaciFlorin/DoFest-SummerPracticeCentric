using AutoMapper;
using DoFest.Business.Models.Activity;
using DoFest.Business.Services.Interfaces;
using DoFest.Persistence.Activities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace DoFest.Business.Services.Implementations
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
