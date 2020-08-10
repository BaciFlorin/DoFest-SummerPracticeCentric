using DoFest.Entities.Authentication.Notification;
using System;

namespace DoFest.IntegrationTests.Shared.Factories
{
    public static class NotificationFactory
    {
        public static Notification Default(Guid activityId)
        {
            return new Notification(
                activityId,
                DateTime.Now,
                "notificare test"
                );
        }
    }
}
