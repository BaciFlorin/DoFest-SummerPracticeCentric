
using DoFest.Entities.Activities.Content;
using DoFest.Entities.Lists;
using System;
using System.Collections.Generic;

namespace DoFest.Business.Models.Activity
{
    public sealed class ActivityModel
    {
        public Guid? ActivityTypeId { get; private set; }

        public Guid? LocationId { get; private set; }

        public ICollection<Photo> Photos { get; private set; }
        public ICollection<Comment> Comments { get; private set; }

        public ICollection<Rating> Ratings { get; private set; }

        public ICollection<Note> Notes { get; private set; }

       public string Description { get; private set; }

        public ICollection<BucketListActivity> BucketListActivities { get; private set; }
    }
}
