using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DoFest.Business.Activities.Services.Interfaces;
using DoFest.Business.Models.Activity;
using DoFest.Entities.Activities;
using DoFest.Persistence.Activities;

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

        public async Task Delete(Guid activityId)
        {
            var activity = await _repository.GetById(activityId);

            _repository.Delete(activity);
            await _repository.SaveChanges();
        }

        public async Task<IList<ActivityModel>> GetActivityLists()
        {
            var activityList = await _repository.GetActivityLists();

            //var activityModel = new List<ActivityModel>();

            var acList = _mapper.Map<List<ActivityModel>>(activityList);

            return acList;
        }

        public async Task<ActivityModel> Add(CreateActivityModel model)
        {
            var activity = _mapper.Map<Activity>(model);

            await _repository.Add(activity);
            await _repository.SaveChanges();

            return _mapper.Map<ActivityModel>(activity);
        }

        public Task<ActivityModel> GetIdByType(string activityType)
        {
            // var activity = await _repository.get
            throw new ExecutionEngineException();
        }
    }
}

