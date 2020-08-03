using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Entities.Activities;

namespace DoFest.Persistence.Activities.ActivityTypes
{
    public interface IActivityTypesRepository: IRepository<ActivityType>
    {
        public Task<IList<ActivityType>> GetAll();

        Task<ActivityType> GetByName(string name);
    }
}
