using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Models.Activity;
using DoFest.Business.Activities.Services.Interfaces;
using DoFest.Business.Errors;
using DoFest.Entities.Activities;
using DoFest.Persistence.Activities;
using DoFest.Persistence.Activities.ActivityTypes;
using DoFest.Persistence.Activities.Places;
using DoFest.Persistence.Authentication;
using DoFest.Persistence.Authentication.Type;
using Microsoft.AspNetCore.Http;

namespace DoFest.Business.Activities.Services.Implementations
{
    public sealed class ActivitiesService : IActivitiesService
    {
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IActivityTypesRepository _activityTypesRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IHttpContextAccessor _accessor;
        private readonly IMapper _mapper;

        public ActivitiesService(
            IActivitiesRepository repository, 
            IActivityTypesRepository activityTypesRepository, 
            ICityRepository cityRepository,
            IUserRepository userRepository,
            IUserTypeRepository userTypeRepository,
            IMapper mapper,
            IHttpContextAccessor accessor
            )
        {
            _activitiesRepository = repository;
            _activityTypesRepository = activityTypesRepository;
            _cityRepository = cityRepository;
            _userRepository = userRepository;
            _userTypeRepository = userTypeRepository;
            _mapper = mapper;
            _accessor = accessor;
        }


        public async Task<Result<ActivityModel, Error>> Get(Guid activityId)
        {
            var activity = await _activitiesRepository.GetById(activityId);
            return activity == null ? Result.Failure<ActivityModel, Error>(ErrorsList.UnavailableActivity) : _mapper.Map<ActivityModel>(activity);
        }

        public async Task<Result<ActivityModel,Error>> Delete(Guid activityId)
        {
            // Check authority
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var user = await _userRepository.GetById(userId);
            var userType = await _userTypeRepository.GetByName("Admin");
            if (userType.Id != user.UserTypeId)
            {
                return Result.Failure<ActivityModel, Error>(ErrorsList.UnauthorizedUser);
            }

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
            var activityList = await _activitiesRepository.GetActivityListsWithBucketListActivity();
            var returnList = activityList.OrderBy((a) => a.BucketListActivities.Count())
                .Reverse()
                .ToList()
                .Select((activity) => new ActivityModel(activity.Id,activity.ActivityTypeId, 
                                                        activity.Name, activity.CityId, activity.Address, 
                                                        activity.Description, activity.BucketListActivities.Count())).ToList();

            return Result.Success<IList<ActivityModel>, Error>(returnList);
        }

        public async Task<Result<ActivityModel, Error>> Add(CreateActivityModel model)
        {
            // Check authority
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var user = await _userRepository.GetById(userId);
            var userType = await _userTypeRepository.GetByName("Admin");
            if (userType.Id != user.UserTypeId)
            {
                return Result.Failure<ActivityModel, Error>(ErrorsList.UnauthorizedUser);
            }

            var isActivityTypeNull = (await _activityTypesRepository.GetById(model.ActivityTypeId)) == null;
            if (isActivityTypeNull)
            {
                return Result.Failure<ActivityModel, Error>(ErrorsList.UnavailableActivityType);
            }
            var isCityNull = (await _cityRepository.GetById(model.CityId)) == null;
            if (isCityNull)
            {
                return Result.Failure<ActivityModel, Error>(ErrorsList.InvalidCity);
            }
            var activityModel = await _activitiesRepository.GetByName(model.Name);
            if (activityModel != null)
            {
                return Result.Failure<ActivityModel, Error>(ErrorsList.ActivityExists);
            }

            var activityEntity = _mapper.Map<Activity>(model);

            await _activitiesRepository.Add(activityEntity);
            await _activitiesRepository.SaveChanges();

            return _mapper.Map<ActivityModel>(activityEntity);
        }
    }
}

