using DoFest.Entities.Authentication;
using DoFest.Entities.Lists;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoFest.Entities.Activities;

namespace DoFest.Persistence.BucketLists
{

    public sealed class BucketListRepository : Repository<BucketList>, IBucketListRepository
    {
        public BucketListRepository(DoFestContext context) : base(context)
        {
        }

        public async Task<IList<BucketList>> GetBucketLists()
            => await context
                .BucketLists
                .ToListAsync();

        public async Task<BucketListActivity> GetBucketListActivityById(Guid bucketlistId, Guid activityId)
            => await context
                .BucketListActivities
                .FirstAsync(bla => bla.BucketListId == bucketlistId && bla.ActivityId == activityId);

        public async Task<BucketList> GetByIdWithActivities(Guid userId)
            => await context.BucketLists.Include(b => b.BucketListActivities)
                .FirstAsync(list => list.UserId == userId);
    }
}
