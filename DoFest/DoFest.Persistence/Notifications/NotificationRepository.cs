using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoFest.Entities.Authentication.Notification;
using Microsoft.EntityFrameworkCore;

namespace DoFest.Persistence.Notifications
{
    public sealed class NotificationRepository:Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(DoFestContext context) : base(context)
        {

        }

        public async Task<IList<Notification>> GetNotificationsByActivityId(IList<Guid> activitiesId)
            => await context.Notifications.Where(not => activitiesId.Contains((Guid) not.ActivityId)).ToListAsync();

    }
}