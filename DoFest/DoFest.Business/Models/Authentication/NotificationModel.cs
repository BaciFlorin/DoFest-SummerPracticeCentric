using System;

namespace DoFest.Business.Models.Authentication
{
    public sealed class NotificationModel
    {
        public Guid? UserId { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }
    }
}
