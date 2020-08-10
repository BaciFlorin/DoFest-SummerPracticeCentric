using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DoFest.Entities.Lists
{
    [Table("BucketList")]
    public class BucketList:Entity
    {
        private BucketList():base()
        {
            BucketListActivities = new List<BucketListActivity>();
        }

        public BucketList(
            Guid UserId,
            string Name
            ) : base()
        {
            this.UserId = UserId;
            this.Name = Name;
            BucketListActivities = new List<BucketListActivity>();
        }

        [Required]
        public Guid UserId { get; private set; }

        [Required, MaxLength(100), MinLength(6)]
        public string Name { get; private set; }

        public ICollection<BucketListActivity> BucketListActivities { get; private set; }
        public void AddBucketListActivity(BucketListActivity activity)
            => this.BucketListActivities.Add(activity);

        public void RemoveActivity(Guid activityId)
        {
            var activity = this.BucketListActivities.FirstOrDefault(bucketlistactivity => bucketlistactivity.ActivityId == activityId);

            if (activity != null)
            {
                this.BucketListActivities.Remove(activity);
            }
        }

        public void RemoveActivities(List<Guid> activities)
            => activities.ForEach(RemoveActivity);

        public void UpdateName(string name)
            => this.Name = name;
    }
}