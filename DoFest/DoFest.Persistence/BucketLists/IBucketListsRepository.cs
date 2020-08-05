using DoFest.Entities.Lists;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoFest.Persistence.BucketLists
{
    public interface IBucketListsRepository:IRepository<BucketList>
    {

        Task<IList<BucketList>> GetBucketLists();
        Task<BucketListActivity> GetBucketListActivityById(Guid bucketlistId, Guid activityId);
        Task<BucketList> GetByIdWithActivities(Guid bucketListId);
        Task<BucketList> GetByUserIdWithActivities(Guid userId);
        Task<BucketList> GetByUserId(Guid userId);
    }
}
