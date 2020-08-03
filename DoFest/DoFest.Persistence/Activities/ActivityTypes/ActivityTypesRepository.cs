using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Entities.Activities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DoFest.Persistence.Activities.ActivityTypes
{
    public sealed class ActivityTypesRepository:Repository<ActivityType>, IActivityTypesRepository
    {
        public ActivityTypesRepository(DoFestContext context) : base(context)
        {

        }

        public async Task<IList<ActivityType>> GetAll()
            => await context
                .ActivityTypes
                .ToListAsync();

        public async Task<ActivityType> GetByName(string name)
        => await context
            .ActivityTypes
            .Where(activityType => activityType.Name == name).FirstOrDefaultAsync();
    }
}
