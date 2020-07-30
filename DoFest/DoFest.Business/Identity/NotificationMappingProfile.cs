using AutoMapper;
using DoFest.Business.Identity.Models.Notifications;
using DoFest.Entities.Authentication.Notification;

namespace DoFest.Business.Identity
{
    public class NotificationMappingProfile:Profile
    {
        public NotificationMappingProfile()
        {
            CreateMap<Notification, NotificationModel>();
            CreateMap<Notification, NewNotificationModel>();
        }
    }
}