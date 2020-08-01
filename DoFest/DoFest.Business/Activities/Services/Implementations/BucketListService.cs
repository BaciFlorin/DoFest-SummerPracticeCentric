using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Services.Interfaces;
using DoFest.Business.Errors;
using DoFest.Business.Models.BucketList;
using DoFest.Entities.Lists;
using DoFest.Persistence.Activities;
using DoFest.Persistence.Authentication;
using DoFest.Persistence.BucketLists;

namespace DoFest.Business.Activities.Services.Implementations
{
    public class BucketListService:IBucketListService
    {
        private readonly IMapper _mapper;
        private readonly IBucketListRepository _bucketListRepository;
        public readonly IUserRepository _userRepository;
        public readonly IActivitiesRepository _activitiesRepository;

        public BucketListService(IBucketListRepository repository, IMapper mapper, IUserRepository userRepository, IActivitiesRepository activitiesRepository)
        {
            _bucketListRepository = repository;
            _mapper = mapper;
            _userRepository = userRepository;
            _activitiesRepository = activitiesRepository;
        }

        public async Task<BucketListModel> Get(Guid bucketListId)
        {
            var bucketList = await _bucketListRepository.GetById(bucketListId);

            var user = await _userRepository.GetById(bucketList.UserId);

            var bucketListModel = BucketListModel.Create(bucketList.UserId, bucketList.Name, user.Username);

            return bucketListModel;
        }

        public async Task<IList<BucketListModel>> GetBucketLists()
        {
            var bucketlists = await _bucketListRepository.GetBucketLists();

            var bucketListModel = new List<BucketListModel>();

            foreach (var bucketList in bucketlists)
            {
                var user = await _userRepository.GetById(bucketList.UserId);

                bucketListModel.Add(BucketListModel.Create(bucketList.Id, bucketList.Name, user.Username));
            }

            return bucketListModel;
        }

        public async Task<Result<BucketListModel, Error>> Add(Guid bucketListId, Guid activityId)
        {

            var bucketList = await _bucketListRepository.GetById(bucketListId);
            if (bucketList == null)
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.UnavailableBucketList);

            }

            var activity = await _activitiesRepository.GetById(activityId);
            if (activity == null)
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.UnavailableActivity);

            }

            var bucketListActivity = new BucketListActivity();
            bucketListActivity.BucketListId = bucketListId;
            bucketListActivity.ActivityId = activityId;
            bucketListActivity.Status = "On Hold";


            bucketList.AddBucketListActivity(bucketListActivity);

            _bucketListRepository.Update(bucketList);

            await _bucketListRepository.SaveChanges();

            return _mapper.Map<BucketListModel>(bucketList);

        }

        public async Task<BucketListModel> DeleteActivity(Guid bucketListId, Guid activityId)
        {
            // TODO: exception handle

            var bucketlist = await _bucketListRepository.GetById(bucketListId);
            var activity = bucketlist
                .BucketListActivities
                .FirstOrDefault(activity => activity.ActivityId == activityId);
 
                bucketlist.RemoveActivity(activityId);
       

            _bucketListRepository.Update(bucketlist);
            await _bucketListRepository.SaveChanges();

            return _mapper.Map<BucketListModel>(bucketlist);
        }

        public async Task<BucketListModel> ToggleStatus(Guid bucketListId, Guid activityId)
        {
            var bucketlistActivity = await _bucketListRepository.GetBucketListActivityById(bucketListId, activityId);
            var bucketlist = await _bucketListRepository.GetById(bucketListId);
            try
            {
                bucketlistActivity?.UpdateStatus();
                _bucketListRepository.Update(bucketlist);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            _bucketListRepository.Update(bucketlist);
            await _bucketListRepository.SaveChanges();
            return _mapper.Map<BucketListModel>(bucketlist);
        }

    }
}
