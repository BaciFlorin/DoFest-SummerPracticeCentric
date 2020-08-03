using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using DoFest.Business.Errors;
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
        private readonly IBucketListsRepository _bucketListRepository;
        private readonly IHttpContextAccessor _accessor;
        private readonly INotificationRepository _notificationRepository;
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IMapper _mapper;

        public NotificationService(IBucketListsRepository bucketListRepository, 
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
            _mapper = mapper;
        }

        public async Task<IList<NotificationModel>> FindAllNotifications()
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);

            var bucketList = await _bucketListRepository.GetByUserIdWithActivities(userId);
            var activitiesId = bucketList.BucketListActivities.Select(bActivity => bActivity.ActivityId).ToList();
            var notifications = await _notificationRepository.GetNotificationsByActivityId(activitiesId);
            return _mapper.Map<IList<NotificationModel>>(notifications);
        }

        public async Task<Result<NewNotificationModel, Error>> CreateNotification(CreateNotificationModel model)
        {
            var existsActivity = (await _activitiesRepository.GetById(model.ActivityId)) != null;
            if (!existsActivity)
            {
                return Result.Failure<NewNotificationModel, Error>(ErrorsList.UnavailableActivity);
            }

            var notification = new Notification()
            {
                ActivityId =  model.ActivityId,
                Date = model.Date,
                Description = model.Description
            };

            await _notificationRepository.Add(notification);
            await _notificationRepository.SaveChanges();
            return Result.Success<NewNotificationModel,Error>(_mapper.Map<NewNotificationModel>(notification));
        }
    }
}