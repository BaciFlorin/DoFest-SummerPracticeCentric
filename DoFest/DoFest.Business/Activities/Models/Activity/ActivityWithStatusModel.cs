using System;

namespace DoFest.Business.Activities.Models.Activity
{
    public sealed class ActivityWithStatusModel
    {
        public Guid ActivityId { get; private set; }

        public string Name { get; private set; }

        public string Status { get; private set; }

        public static ActivityWithStatusModel Create(Guid activityId, string status, string name)
        {
            return new ActivityWithStatusModel
            {
                ActivityId = activityId,
                Status = status,
                Name = name
            };
        }
    }
}
