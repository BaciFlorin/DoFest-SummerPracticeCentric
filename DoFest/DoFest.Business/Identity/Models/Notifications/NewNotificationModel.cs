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

        public Guid Id { get; private set; }
        public Guid ActivityId { get; private set; }

        public DateTime Date { get; private set; }

        public string Description { get; private set; }
    }
}