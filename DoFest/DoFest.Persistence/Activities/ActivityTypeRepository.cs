using DoFest.Entities.Activities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoFest.Persistence.Activities
{
    
    public sealed class ActivityTypeRepository : Repository<ActivityType>, IActivityTypeRepository
    {
        public ActivityTypeRepository(DoFestContext context) : base(context)
        {

        }

        public async Task<IList<ActivityType>> GetActivityTypeList()
            => await context
            .ActivityTypes
            .ToListAsync();
    }
}
