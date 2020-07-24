using DoFest.Business.Models.BucketList;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoFest.Business.Services.Interfaces
{
    public interface IBucketListService
    {
        public Task<BucketListModel> Get(Guid bucketListId);

        public Task<BucketListModel> Add(Guid bucketList, Guid activityId);
    }
}
