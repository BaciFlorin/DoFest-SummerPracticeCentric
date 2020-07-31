using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DoFest.Business.Activities.Models.Activity.ActivityType;
using DoFest.Business.Activities.Services.Interfaces;
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

        public async Task<IEnumerable<ActivityTypeModel>> Get()
        {
            var activityTypes = await _activityTypesRepository.GetAll();

            return _mapper.Map<IEnumerable<ActivityTypeModel>>(activityTypes);
        }

        public async Task<ActivityTypeModel> Add(CreateActivityTypeModel model)
        {
            var activityType = _mapper.Map<ActivityType>(model);

            await _activityTypesRepository.Add(activityType);
            await _activityTypesRepository.SaveChanges();

            return _mapper.Map<ActivityTypeModel>(activityType);
        }
    }
}
