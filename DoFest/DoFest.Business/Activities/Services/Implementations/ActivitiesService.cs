using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Services.Interfaces;
using DoFest.Business.Errors;
using DoFest.Business.Models.Activity;
using DoFest.Entities.Activities;
using DoFest.Persistence.Activities;

namespace DoFest.Business.Activities.Services.Implementations
{
    public sealed class ActivitiesService : IActivitiesService
    {
        private readonly IMapper _mapper;
        private readonly IActivitiesRepository _activitiesRepository;

        public ActivitiesService(IActivitiesRepository repository, IMapper mapper)
        {
            _activitiesRepository = repository;
            _mapper = mapper;
        }


        public async Task<Result<ActivityModel, Error>> Get(Guid activityId)
        {

            var activity = await _activitiesRepository.GetById(activityId);
            if (activity == null)
            {
                return Result.Failure<ActivityModel, Error>(ErrorsList.UnavailableActivity);
            }

            return _mapper.Map<ActivityModel>(activity);

        }

        public async Task<Result<ActivityModel,Error>> Delete(Guid activityId)
        {
            var activity = await _activitiesRepository.GetById(activityId);
            if (activity == null)
            {
                return Result.Failure<ActivityModel, Error>(ErrorsList.UnavailableActivity);
            }

            _activitiesRepository.Delete(activity);
            await _activitiesRepository.SaveChanges();

            return _mapper.Map<ActivityModel>(activity);
        }

        public async Task<Result<IList<ActivityModel>,Error>> GetActivityLists()
        {
            var activityList = await _activitiesRepository.GetActivityLists();

            return _mapper.Map<List<ActivityModel>>(activityList);
        }

        public async Task<Result<ActivityModel, Error>> Add(CreateActivityModel model)
        {
            var act = await _activitiesRepository.GetByName(model.Name);

            if (act != null)
            {
                return Result.Failure<ActivityModel, Error>(ErrorsList.ActivityExists);
            }

            var activity = _mapper.Map<Activity>(model);

            await _activitiesRepository.Add(activity);
            await _activitiesRepository.SaveChanges();

            return Result.Success<ActivityModel, Error>(_mapper.Map < ActivityModel>(activity));
        }
    }
}

