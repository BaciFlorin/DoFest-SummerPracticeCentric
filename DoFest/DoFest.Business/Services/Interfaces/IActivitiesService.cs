using DoFest.Business.Models.Activity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoFest.Business.Services.Interfaces
{
    public interface IActivitiesService
    {
        public Task<ActivityModel> Get(Guid activityId);

        public Task<ActivityModel> Add(CreateActivityModel model);

        public Task<IList<ActivityModel>> GetActivityLists();

        public Task Delete(Guid activityId);

    }
}
