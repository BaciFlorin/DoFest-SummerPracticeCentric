using DoFest.Business.Models.Activity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoFest.Business.Services.Interfaces
{
    public interface IActivitiesService
    {
        public Task<ActivityModel> Get(Guid activityId);
        
    }
}
