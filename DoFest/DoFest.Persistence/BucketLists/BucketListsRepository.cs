using DoFest.Entities.Lists;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoFest.Persistence.BucketLists
{

    public sealed class BucketListsRepository : Repository<BucketList>, IBucketListsRepository
    {
        public BucketListsRepository(DoFestContext context) : base(context)
        {

        }

        public async Task<IList<BucketList>> GetBucketLists()
            => await context
                .BucketLists
                .ToListAsync();

        public async Task<BucketListActivity> GetBucketListActivityById(Guid bucketListId, Guid activityId)
            => await context
                .BucketListActivities
                .FirstAsync(bucketListActivity => bucketListActivity.BucketListId == bucketListId && bucketListActivity.ActivityId == activityId);

        public async Task<BucketList> GetByIdWithActivities(Guid bucketListId)
            => await context
                .BucketLists
                .Include(b => b.BucketListActivities)
                .FirstAsync(bucketList => bucketList.Id == bucketListId);

        public async Task<BucketList> GetByUserIdWithActivities(Guid userId)
            => await context
                .BucketLists
                .Include(b => b.BucketListActivities)
                .FirstAsync(bucketList => bucketList.UserId == userId);

        public async Task<BucketList> GetByUserId(Guid userId)
            => await context
                .BucketLists
                .FirstAsync(bucketList => bucketList.UserId == userId);
    }
}
