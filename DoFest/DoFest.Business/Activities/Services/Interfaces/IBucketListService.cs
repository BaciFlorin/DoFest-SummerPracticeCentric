using CSharpFunctionalExtensions;
using DoFest.Business.Errors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Business.Activities.Models.BucketList;

namespace DoFest.Business.Activities.Services.Interfaces
{
    public interface IBucketListService
    {
        public Task<Result<BucketListWithActivityIdModel, Error>> Get(Guid bucketListId);
        public Task<Result<IList<BucketListModel>, Error>> GetBucketLists();
        public Task<Result<BucketListModel, Error>> Add(Guid bucketListId, Guid activityId);
        //public Task<Result<BucketListModel, Error>> DeleteActivity(Guid bucketList, Guid activityId);
        public Task<Result<string, Error>> UpdateBucketList(Guid bucketListId, BucketListUpdateModel updateModel);

    }
}
