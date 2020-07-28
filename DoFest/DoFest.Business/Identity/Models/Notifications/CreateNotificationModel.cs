using System;

namespace DoFest.Business.Identity.Models.Notifications
{
    public sealed class CreateNotificationModel
    {
        public Guid ActivityId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}