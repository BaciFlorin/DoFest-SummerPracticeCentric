using DoFest.Business.Models.BucketList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoFest.Business.Services.Interfaces
{
    public interface IBucketListService
    {
        public Task<BucketListModel> Get(Guid bucketListId);
        public Task<IList<BucketListModel>> GetBucketLists();
        public Task<BucketListModel> Add(Guid bucketList, Guid activityId);
        public Task<BucketListModel> DeleteActivity(Guid bucketList, Guid activityId);
        public Task<BucketListModel> ToggleStatus(Guid bucketListId, Guid activityId);
    }
}
