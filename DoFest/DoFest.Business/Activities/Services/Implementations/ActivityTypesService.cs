using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Models.Activity.ActivityType;
using DoFest.Business.Activities.Services.Interfaces;
using DoFest.Business.Errors;
using DoFest.Entities.Activities;
using DoFest.Persistence.Activities.ActivityTypes;

namespace DoFest.Business.Activities.Services.Implementations
{
    public class ActivityTypesService:IActivityTypesService
    {
        private readonly IMapper _mapper;
        private readonly IActivityTypesRepository _activityTypesRepository;

        public ActivityTypesService(IMapper mapper, IActivityTypesRepository activityTypesRepository)
        {
            _mapper = mapper;
            _activityTypesRepository = activityTypesRepository;
        }

        public async Task<Result<IEnumerable<ActivityTypeModel>, Error>> Get()
        {
            var activityTypes = await _activityTypesRepository.GetAll();

            return Result.Success<IEnumerable<ActivityTypeModel>, Error>(
                _mapper.Map<IEnumerable<ActivityTypeModel>>(activityTypes));
        }

        public async Task<Result<ActivityTypeModel, Error>> Add(CreateActivityTypeModel model)
        {
            var activityTypeExists = (await _activityTypesRepository.GetByName(model.Name)) != null;
            if (activityTypeExists)
            {
                return Result.Failure<ActivityTypeModel, Error>(ErrorsList.ActivityTypeExists);
            }

            var activityType = _mapper.Map<ActivityType>(model);

            await _activityTypesRepository.Add(activityType);
            await _activityTypesRepository.SaveChanges();

            return _mapper.Map<ActivityTypeModel>(activityType);
        }

        public async Task<Result<string, Error>> Delete(Guid activityTypeId)
        {
            var activityType = await _activityTypesRepository.GetById(activityTypeId);
            if (activityType == null)
            {
                return Result.Failure<string, Error>(ErrorsList.UnavailableActivityType);
            }

            _activityTypesRepository.Delete(activityType);
            await _activityTypesRepository.SaveChanges();

            return Result.Success<string, Error>("ActivityType deleted successfully");
        }
    }
}
