using DoFest.Entities.Activities.Content;
using DoFest.Entities.Lists;
using System;
using System.Collections.Generic;

namespace DoFest.Business.Models.Activity
{
    public sealed class ActivityModel
    {
        public Guid? ActivityTypeId { get; private set; }

        public Guid? Id { get; private set; }

        public Guid? LocationId { get; private set; }

        public string Description { get; private set; }

    }
}
