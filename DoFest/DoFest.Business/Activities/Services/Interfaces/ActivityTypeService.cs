using AutoMapper;
using DoFest.Business.Models.Activity;
using DoFest.Business.Services.Interfaces;
using DoFest.Persistence.Activities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoFest.Business.Services.Implementations
{
    public class ActivityTypeService : IActivityTypeService
    {
        private readonly IActivityTypeRepository _repository;
        private readonly IMapper _mapper;

        public ActivityTypeService(IActivityTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<ActivityTypeModel>> GetActivitiesType()
        {
            var activityTypeList = await _repository.GetActivityTypeList();

            var acList = _mapper.Map<IList<ActivityTypeModel>>(activityTypeList);

            return acList;
        }

        public Task<Guid> GetIdByType(string activityType)
        {
            throw new NotImplementedException();
        }
    }
}
