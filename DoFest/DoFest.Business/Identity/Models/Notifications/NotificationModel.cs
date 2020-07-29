using System;

namespace DoFest.Business.Identity.Models.Notifications
{
    public sealed class NotificationModel
    {
        public Guid ActivityId  { get; private set; }

        public DateTime Date { get; private set; }

        public string Description { get; private set; }
    }
}
