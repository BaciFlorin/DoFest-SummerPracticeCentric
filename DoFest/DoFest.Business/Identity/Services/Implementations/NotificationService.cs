using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DoFest.Business.Identity.Models.Notifications;
using DoFest.Business.Identity.Services.Interfaces;
using DoFest.Entities.Authentication.Notification;
using DoFest.Persistence.Activities;
using DoFest.Persistence.Authentication;
using DoFest.Persistence.BucketLists;
using DoFest.Persistence.Notifications;
using Microsoft.AspNetCore.Http;

namespace DoFest.Business.Identity.Services.Implementations
{
    public sealed class NotificationService: INotificationService
    {
        private readonly IBucketListRepository _bucketListRepository;
        private readonly IHttpContextAccessor _accessor;
        private readonly INotificationRepository _notificationRepository;
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public NotificationService(IBucketListRepository bucketListRepository, 
            IHttpContextAccessor accessor,
            INotificationRepository notificationRepository,
            IActivitiesRepository activitiesRepository, 
            IUserRepository userRepository,
            IMapper mapper)
        {
            _bucketListRepository = bucketListRepository;
            _accessor = accessor;
            _notificationRepository = notificationRepository;
            _activitiesRepository = activitiesRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IList<NotificationModel>> FindAllNotifications()
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var bucketList = await _bucketListRepository.GetByIdWithActivities(userId);
            var activitiesId = bucketList.BucketListActivities.Select(bActivity => bActivity.ActivityId).ToList();
            var notifications = await _notificationRepository.GetNotificationsByActivityId(activitiesId);
            return _mapper.Map<IList<NotificationModel>>(notifications);
        }

        public async Task<NewNotificationModel> CreateNotification(CreateNotificationModel model)
        {
            var existsActivity = (await _activitiesRepository.GetById(model.ActivityId)) != null;
            if (!existsActivity)
            {
                return null;
            }
            var notification = new Notification()
            {
                ActivityId =  model.ActivityId,
                Date = model.Date,
                Description = model.Description
            };

            await _notificationRepository.Add(notification);
            await _notificationRepository.SaveChanges();
            return _mapper.Map<NewNotificationModel>(notification);
        }
    }
}