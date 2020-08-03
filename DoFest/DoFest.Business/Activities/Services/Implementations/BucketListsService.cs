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
        private readonly IMapper _mapper;
        private readonly IBucketListsRepository _bucketListRepository;
        private readonly IUserRepository _userRepository;
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IHttpContextAccessor _accessor;

        public BucketListsService(
            IBucketListsRepository repository,
            IMapper mapper, 
            IUserRepository userRepository, 
            IActivitiesRepository activitiesRepository,
            IUserTypeRepository userTypeRepository,
            IHttpContextAccessor accessor
            )
        {
            _bucketListRepository = repository;
            _mapper = mapper;
            _userRepository = userRepository;
            _activitiesRepository = activitiesRepository;
            _accessor = accessor;
            _userTypeRepository = userTypeRepository;
        }

        public async Task<Result<BucketListWithActivityIdModel, Error>> Get(Guid bucketListId)
        {
            var bucketListExists = (await _bucketListRepository.GetById(bucketListId)) != null;
            if (!bucketListExists)
            {
                return Result.Failure<BucketListWithActivityIdModel, Error>(ErrorsList.UnavailableBucketList);
            }

            var bucketList = await _bucketListRepository.GetByIdWithActivities(bucketListId);
            var user = await _userRepository.GetById(bucketList.UserId);

            var bucketListActivities = bucketList.BucketListActivities.ToList();
            var activities = bucketListActivities.Select(activity => ActivityWithStatusModel.Create(activity.ActivityId, activity.Status)).ToList();

            return BucketListWithActivityIdModel.Create(bucketList.Id, activities, bucketList.Name, user.Username);
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
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var bucketListExists = (await _bucketListRepository.GetById(bucketListId)) != null;
            if (!bucketListExists)
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.UnavailableBucketList);
            }

            var bucketList = await _bucketListRepository.GetByIdWithActivities(bucketListId);

            var user = await _userRepository.GetById(bucketList.UserId);

            if (userId != bucketList.UserId)
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.UnauthorizedUser);
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

            return BucketListModel.Create(bucketList.Id, bucketList.Name, user.Username);
        }

        /// <summary>
        /// Schimba statusul unei activitati din bucket list: Completed/On hold.
        /// </summary>
        /// <param name="bucketListId"> Id-ul bucket list-ului. </param>
        /// <param name="activityId"> Id-ul activitatii. </param>
        /// <returns> Modelul bucket list-ului care a fost updatat sau null. </returns>
        public async Task<Result<BucketListModel, Error>> ToggleStatus(Guid bucketListId, Guid activityId)
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
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
            if (userId != bucketList.UserId)
            {
                return Result.Failure<BucketListModel, Error>(ErrorsList.UnauthorizedUser);
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
