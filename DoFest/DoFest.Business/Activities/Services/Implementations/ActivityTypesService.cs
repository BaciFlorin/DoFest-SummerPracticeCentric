using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Models.Activity.ActivityType;
using DoFest.Business.Activities.Services.Interfaces;
using DoFest.Business.Errors;
using DoFest.Entities.Activities;
using DoFest.Persistence.Activities.ActivityTypes;
using DoFest.Persistence.Authentication;
using DoFest.Persistence.Authentication.Type;
using Microsoft.AspNetCore.Http;

namespace DoFest.Business.Activities.Services.Implementations
{
    public class ActivityTypesService:IActivityTypesService
    {
        private readonly IMapper _mapper;
        private readonly IActivityTypesRepository _activityTypesRepository;
        private readonly IHttpContextAccessor _accessor;
        private readonly IUserRepository _userRepository;
        private readonly IUserTypeRepository _userTypeRepository;

        public ActivityTypesService(IMapper mapper, IActivityTypesRepository activityTypesRepository,
            IUserRepository userRepository, IHttpContextAccessor accessor, IUserTypeRepository userTypeRepository)
        {
            _mapper = mapper;
            _activityTypesRepository = activityTypesRepository;
            _userRepository = userRepository;
            _accessor = accessor;
            _userTypeRepository = userTypeRepository;
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

            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var user = await _userRepository.GetById(userId);
            var userType = await _userTypeRepository.GetByName("Admin");
            if (user.UserTypeId != userType.Id)
            {
                return Result.Failure<ActivityTypeModel, Error>(ErrorsList.UnauthorizedUser);
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

            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var user = await _userRepository.GetById(userId);
            var userType = await _userTypeRepository.GetByName("Admin");
            if (user.UserTypeId != userType.Id)
            {
                return Result.Failure<string, Error>(ErrorsList.UnauthorizedUser);
            }

            _activityTypesRepository.Delete(activityType);
            await _activityTypesRepository.SaveChanges();

            return Result.Success<string, Error>("ActivityType deleted successfully");
        }
    }
}
