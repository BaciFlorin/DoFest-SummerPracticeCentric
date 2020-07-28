using System;
using System.Threading.Tasks;
using DoFest.Business.Activities.Models.Activity;

namespace DoFest.Business.Activities.Services.Interfaces
{
    public interface IActivitiesService
    {
        public Task<ActivityModel> Get(Guid activityId);
        
    }
}
