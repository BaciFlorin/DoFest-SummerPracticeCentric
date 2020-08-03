using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Models.Activity.ActivityType;
using DoFest.Business.Errors;

namespace DoFest.Business.Activities.Services.Interfaces
{
    public interface IActivityTypesService
    {
        Task<Result<IEnumerable<ActivityTypeModel>, Error>> Get();

        Task<Result<ActivityTypeModel, Error>> Add(CreateActivityTypeModel model);

        Task<Result<string, Error>> Delete(Guid activityTypeId);
    }
}
