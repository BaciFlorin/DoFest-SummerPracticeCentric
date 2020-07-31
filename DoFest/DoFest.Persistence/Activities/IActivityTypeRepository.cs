using DoFest.Entities.Activities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoFest.Persistence.Activities
{
    public interface IActivityTypeRepository : IRepository<ActivityType>
    {
        public Task<IList<ActivityType>> GetActivityTypeList();
    }
}
