using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using DoFest.Business.Identity.Models.Notifications;
using DoFest.Business.Identity.Services.Interfaces;
using DoFest.Entities.Authentication.Notification;
using DoFest.Persistence.Activities;
using DoFest.Persistence.BucketLists;
using Microsoft.AspNetCore.Http;

namespace DoFest.Business.Identity.Services.Implementations
{
    public sealed class NotificationService: INotificationService
    {
        private readonly IBucketListsRepository _bucketListRepository;
        private readonly IHttpContextAccessor _accessor;
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IMapper _mapper;

        public NotificationService(IBucketListsRepository bucketListRepository, 
            IHttpContextAccessor accessor,
            IActivitiesRepository activitiesRepository, 
            IMapper mapper)
        {
            _bucketListRepository = bucketListRepository;
            _accessor = accessor;
            _activitiesRepository = activitiesRepository;
            _mapper = mapper;
        }

        public async Task<IList<NotificationModel>> FindAllNotifications()
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);

            var bucketList = await _bucketListRepository.GetByUserIdWithActivities(userId);
            var activitiesId = bucketList.BucketListActivities.Select(bActivity => bActivity.ActivityId).ToList();
            var notifications = new List<Notification>();
            foreach (var activityId in activitiesId)
            {
                var activity = await _activitiesRepository.GetByIdWithNotifications(activityId);
                notifications.AddRange(activity.Notifications.ToList());
            }
            return _mapper.Map<IList<NotificationModel>>(notifications);
        }
    }
}