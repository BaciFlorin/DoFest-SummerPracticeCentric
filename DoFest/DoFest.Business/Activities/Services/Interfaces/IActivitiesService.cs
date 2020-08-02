using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Models.Activity;
using DoFest.Business.Errors;

namespace DoFest.Business.Activities.Services.Interfaces
{
    public interface IActivitiesService
    {
        public Task<Result<ActivityModel, Error>> Get(Guid activityId);

        public Task<Result<ActivityModel, Error>> Add(CreateActivityModel model);

        public Task<Result<IList<ActivityModel>, Error>> GetActivityLists();

        public Task<Result<ActivityModel, Error>> Delete(Guid activityId);
    }
}
