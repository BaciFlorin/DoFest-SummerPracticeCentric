using System;

namespace DoFest.Business.Identity.Models.Notifications
{
    public sealed class NewNotificationModel
    {
        public NewNotificationModel(Guid activityId, DateTime date, string description)
        {
            ActivityId = activityId;
            Date = date;
            Description = description;
        }

        public Guid Id { get; set; }
        public Guid ActivityId { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }
    }
}