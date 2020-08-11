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
using DoFest.Persistence.Authentication.Type;
using DoFest.Persistence.BucketLists;
using Microsoft.AspNetCore.Http;

namespace DoFest.Business.Activities.Services.Implementations
{
    public class BucketListsService:IBucketListService
    {
        private readonly IBucketListsRepository _bucketListRepository;
        private readonly IUserRepository _userRepository;
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IHttpContextAccessor _accessor;

        public BucketListsService(
            IBucketListsRepository repository,
            IUserRepository userRepository, 
            IActivitiesRepository activitiesRepository,
            IHttpContextAccessor accessor
            )
        {
            _bucketListRepository = repository;
            _userRepository = userRepository;
            _activitiesRepository = activitiesRepository;
            _accessor = accessor;
        }

        public async Task<Result<BucketListWithActivityIdModel, Error>> Get(Guid bucketListId)
        {
            var bucketList = await _bucketListRepository.GetByIdWithActivities(bucketListId);
            if (bucketList == null)
            {
                return Result.Failure<BucketListWithActivityIdModel, Error>(ErrorsList.UnavailableBucketList);
            }

            var user = await _userRepository.GetById(bucketList.UserId);
            var bucketListActivities = bucketList.BucketListActivities.ToList();
            var activities = new List<ActivityWithStatusModel>();
            foreach(var bucketListActivity in bucketListActivities)
            {
                var activity = await _activitiesRepository.GetById(bucketListActivity.ActivityId);
                activities.Add(ActivityWithStatusModel.Create(bucketListActivity.ActivityId, bucketListActivity.Status, activity.Name));
            }

            return BucketListWithActivityIdModel.Create(activities, bucketList.Name, user.Username);
        }

        public async Task<Result<IList<BucketListModel>, Error>> GetBucketLists()
        {
            var bucketListEntity = await _bucketListRepository.GetBucketLists();

            var bucketListModel = new List<BucketListModel>();

            foreach (var bucketList in bucketListEntity)
            {
                var user = await _userRepository.GetById(bucketList.UserId);

                bucketListModel.Add(BucketListModel.Create(bucketList.Id, bucketList.Name, user.Username));
            }

            return bucketListModel;
        }

        public async Task<Result<BucketListModel, Error>> Add(Guid bucketListId, Guid activityId)
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
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
            var user = await _userRepository.GetById(bucketList.UserId);
            if (userId != bucketList.UserId)
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.UnauthorizedUser);
            }

            // Daca activitatea exista deja in bucketlist se returneaza o eroare.
            if (bucketList.BucketListActivities.Any(bucketListActivityQuery => bucketListActivityQuery.ActivityId == activityId))
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.ActivityInBucketListExists);
            }

            var activity = await _activitiesRepository.GetById(activityId);
            if (activity == null)
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.UnavailableActivity);
            }

            var bucketListActivity = new BucketListActivity(bucketListId, activityId);

            bucketList.AddBucketListActivity(bucketListActivity);

            _bucketListRepository.Update(bucketList);

            await _bucketListRepository.SaveChanges();

            return BucketListModel.Create(bucketList.Id, bucketList.Name, user.Username);

        }

        
        /// <summary>
        /// Schimba statusul unei activitati din bucket list: Completed/On hold.
        /// </summary>
        /// <param name="bucketListId"> Id-ul bucket list-ului. </param>
        /// <param name="updateModel"> Modelul care contine informatiile pentru update. </param>
        /// <returns> Modelul bucket list-ului care a fost updatat sau null. </returns>
        public async Task<Result<string, Error>> UpdateBucketList(Guid bucketListId, BucketListUpdateModel updateModel)
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var bucketList = await _bucketListRepository.GetByIdWithActivities(bucketListId);
            if (bucketList == null)
            {
                return Result.Failure<string, Error>(ErrorsList.UnavailableBucketList);
            }

            var user = await _userRepository.GetById(bucketList.UserId);
            if (userId != bucketList.UserId)
            {
                return Result.Failure<string, Error>(ErrorsList.UnauthorizedUser);
            }

            bucketList.RemoveActivities(updateModel.ActivitiesForDelete);

            foreach (var activityId in updateModel.ActivitiesForToggle)
            {
                var bucketListActivity = bucketList.BucketListActivities.First((bucketAct) => bucketAct.ActivityId == activityId);
                bucketListActivity.UpdateStatus();
            }

            bucketList.UpdateName(updateModel.Name);

            _bucketListRepository.Update(bucketList);
            await _bucketListRepository.SaveChanges();

            return Result.Success<string,Error>("Bucketlist updated");
        }

    }
}
