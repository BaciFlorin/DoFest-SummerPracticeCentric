using System;

namespace DoFest.Business.Activities.Models.Activity
{
    public sealed class ActivityModel
    {
        public Guid? ActivityTypeId { get; private set; }
        public Guid? ActivityId { get; private set; }
        public Guid? LocationId { get; private set; }
        public string Description { get; private set; }
    }
}
