using DoFest.Entities.Lists;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoFest.Persistence.BucketLists
{
    public interface IBucketListRepository:IRepository<BucketList>
    {

        Task<IList<BucketList>> GetBucketLists();
        Task<BucketListActivity> GetBucketListActivityById(Guid bucketlistId, Guid activityId);
        Task<BucketList> GetByIdWithActivities(Guid userId);


    }
}
