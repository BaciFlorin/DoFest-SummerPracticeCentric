using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Business.Models.Activity;

namespace DoFest.Business.Activities.Services.Interfaces
{
    public interface IActivitiesService
    {
        public Task<ActivityModel> Get(Guid activityId);

        public Task<ActivityModel> Add(CreateActivityModel model);

        public Task<IList<ActivityModel>> GetActivityLists();

        public Task Delete(Guid activityId);
    }
}
