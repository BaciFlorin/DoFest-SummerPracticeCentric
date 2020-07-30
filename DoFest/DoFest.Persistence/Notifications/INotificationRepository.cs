using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Entities.Authentication.Notification;

namespace DoFest.Persistence.Notifications
{
    public interface INotificationRepository:IRepository<Notification>
    {
        Task<IList<Notification>> GetNotificationsByActivityId(IList<Guid?> activitiesId);
    }
}