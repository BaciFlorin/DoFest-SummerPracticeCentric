using DoFest.Business.Models.Activity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoFest.Business.Services.Interfaces
{
    public interface IActivityTypeService
    {
        public Task<IList<ActivityTypeModel>> GetActivitiesType();

        public Task<Guid>GetIdByType(string activityType);
    }
}
