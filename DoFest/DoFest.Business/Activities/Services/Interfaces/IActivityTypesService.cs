using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Business.Activities.Models.Activity.ActivityType;

namespace DoFest.Business.Activities.Services.Interfaces
{
    public interface IActivityTypesService
    {
        Task<IEnumerable<ActivityTypeModel>> Get();

        Task<ActivityTypeModel> Add(CreateActivityTypeModel model);
    }
}
