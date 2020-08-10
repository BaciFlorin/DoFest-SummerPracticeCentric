using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DoFest.Business.Errors;
using DoFest.Business.Identity.Models.Notifications;

namespace DoFest.Business.Identity.Services.Interfaces
{
    public interface INotificationService
    {
        Task<IList<NotificationModel>> FindAllNotifications();
    }
}