using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Business.Identity.Models.Notifications;

namespace DoFest.Business.Identity.Services.Interfaces
{
    public interface INotificationService
    {
        Task<IList<NotificationModel>> FindAllNotifications();
        Task<NewNotificationModel> CreateNotification(CreateNotificationModel model);
    }
}