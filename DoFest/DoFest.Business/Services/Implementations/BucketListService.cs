using AutoMapper;
using DoFest.Business.Models.BucketList;
using DoFest.Business.Services.Interfaces;
using DoFest.Entities.Lists;
using DoFest.Persistence.BucketLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoFest.Business.Services.Implementations
{
    public class BucketListService:IBucketListService
    {
        private readonly IMapper _mapper;
        private readonly IBucketListRepository _repository;

        public BucketListService(IBucketListRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BucketListModel> Get(Guid bucketListId)
        {

            var bucketList = await _repository.GetById(bucketListId);

            return _mapper.Map<BucketListModel>(bucketList);

        }
        public async Task<IList<BucketListModel>> GetBucketLists()
        {
            var bucketlists = await _repository.GetBucketLists();
            return _mapper.Map<IList<BucketListModel>>(bucketlists);
        }

        public async Task<BucketListModel> Add(Guid bucketListId, Guid activityId)
        {
            var bucketList = await _repository.GetById(bucketListId);
            var bucketListActivity = new BucketListActivity();
            bucketListActivity.BucketListId = bucketListId;
            bucketListActivity.ActivityId = activityId;

            bucketList.AddBucketListActivity(bucketListActivity);

            _repository.Update(bucketList);

            await _repository.SaveChanges();

            return _mapper.Map<BucketListModel>(bucketList);

        }

        public async Task<BucketListModel> DeleteActivity(Guid bucketListId, Guid activityId)
        {
            // TODO: exception handle

            var bucketlist = await _repository.GetById(bucketListId);
            var activity = bucketlist
                .BucketListActivities
                .FirstOrDefault(activity => activity.Id == activityId);
            try
            {
                bucketlist.RemoveActivity(activityId);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            _repository.Update(bucketlist);
            await _repository.SaveChanges();

            return _mapper.Map<BucketListModel>(bucketlist);
        }

        public async Task<BucketListModel> ToggleStatus(Guid bucketListId, Guid activityId)
        {
            var bucketlist = await _repository.GetById(bucketListId);
            var bucketlistActivity = bucketlist
                .BucketListActivities
                .FirstOrDefault(activity => activity.Id == activityId);
            try
            {
                bucketlistActivity?.UpdateStatus();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            _repository.Update(bucketlist);
            await _repository.SaveChanges();
            return _mapper.Map<BucketListModel>(bucketlist);
        }

    }
}
