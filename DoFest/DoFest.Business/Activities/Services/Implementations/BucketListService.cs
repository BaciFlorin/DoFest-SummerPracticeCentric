using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Models.Activity;
using DoFest.Business.Activities.Models.BucketList;
using DoFest.Business.Activities.Services.Interfaces;
using DoFest.Business.Errors;
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

        public async Task<Result<BucketListWithActivityIdModel, Error>> Get(Guid bucketListId)
        {
            var bucketListExists = (await _bucketListRepository.GetById(bucketListId)) != null;
            if (!bucketListExists)
            {
                return Result.Failure<BucketListWithActivityIdModel, Error>(ErrorsList.UnavailableBucketList);
            }

            var bucketList = await _bucketListRepository.GetByIdWithActivities(bucketListId);
            if (bucketList == null)
            {
                return Result.Failure<BucketListWithActivityIdModel, Error>(ErrorsList.UnavailableBucketList);
            }

            var user = await _userRepository.GetById(bucketList.UserId);
            if (user == null)
            {
                return Result.Failure<BucketListWithActivityIdModel, Error>(ErrorsList.UserNotFound);
            }

            var bucketListActivities = bucketList.BucketListActivities.ToList();
            var activities = bucketListActivities.Select(activity => ActivityWithStatusModel.Create(activity.ActivityId, activity.Status)).ToList();

            return BucketListWithActivityIdModel.Create(bucketList.Id, activities, bucketList.Name, user.Username);
        }

        public async Task<Result<IList<BucketListModel>, Error>> GetBucketLists()
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
            var bucketListExists = (await _bucketListRepository.GetById(bucketListId)) != null;
            if (!bucketListExists)
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.UnavailableBucketList);
            }

            var bucketList = await _bucketListRepository.GetByIdWithActivities(bucketListId);
            if (bucketList == null)
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.UnavailableBucketList);
            }
            if (bucketList.BucketListActivities.Any(bucketListActivityQuery => bucketListActivityQuery.ActivityId == activityId) == true)
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.ActivityInBucketListExists);
            }

            var user = await _userRepository.GetById(bucketList.UserId);
            if (user == null)
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.UnavailableBucketList);
            }

            var activity = await _activitiesRepository.GetById(activityId);
            if (activity == null)
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.UnavailableActivity);
            }

            var bucketListActivity = new BucketListActivity
            {
                BucketListId = bucketListId, ActivityId = activityId, Status = "On hold"
            };

            bucketList.AddBucketListActivity(bucketListActivity);

            _bucketListRepository.Update(bucketList);

            await _bucketListRepository.SaveChanges();

            return BucketListModel.Create(bucketList.Id, bucketList.Name, user.Username);

        }

        /// <summary>
        /// Disociaza o activitate inclusa intr-un bucket list.
        /// </summary>
        /// <param name="bucketListId"> Id-ul bucket list-ului. </param>
        /// <param name="activityId"> Id-ul activitatii. </param>
        /// <returns></returns>
        public async Task<Result<BucketListModel, Error>> DeleteActivity(Guid bucketListId, Guid activityId)
        {
            var bucketListExists = (await _bucketListRepository.GetById(bucketListId)) != null;
            if (!bucketListExists)
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.UnavailableBucketList);
            }

            var bucketList = await _bucketListRepository.GetByIdWithActivities(bucketListId);
            if (bucketList == null)
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.UnavailableBucketList);
            }

            var activity = bucketList
                .BucketListActivities
                .FirstOrDefault(activityQuery => activityQuery.ActivityId == activityId);
            if (activity == null)
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.UnavailableActivity);
            }

            bucketList
                .BucketListActivities
                .Remove(activity);

            _bucketListRepository.Update(bucketList);
            await _bucketListRepository.SaveChanges();

            return _mapper.Map<BucketListModel>(bucketList);
        }

        /// <summary>
        /// Schimba statusul unei activitati din bucket list: Completed/On hold.
        /// </summary>
        /// <param name="bucketListId"> Id-ul bucket list-ului. </param>
        /// <param name="activityId"> Id-ul activitatii. </param>
        /// <returns> Modelul bucket list-ului care a fost updatat sau null. </returns>
        public async Task<Result<BucketListModel, Error>> ToggleStatus(Guid bucketListId, Guid activityId)
        {
            var activity = await _activitiesRepository.GetById(activityId);
            if (activity == null)
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.UnavailableActivity);
            }
            var bucketList = await _bucketListRepository.GetById(bucketListId);
            if (bucketList == null)
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.UnavailableBucketList);
            }
            var user = await _userRepository.GetById(bucketList.UserId);
            if (user == null)
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.UserNotFound);
            }

            var bucketListActivity = await _bucketListRepository.GetBucketListActivityById(bucketListId, activityId);
            if (bucketListActivity == null )
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.UnavailableBucketListActivity);
            }

            bucketListActivity.UpdateStatus();
            _bucketListRepository.Update(bucketList);

            await _bucketListRepository.SaveChanges();

            return BucketListModel.Create(bucketList.Id, bucketList.Name, user.Username);
        }

    }
}
