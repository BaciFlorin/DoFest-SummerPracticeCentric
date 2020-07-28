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
        public BucketList():base()
        {
            BucketListActivities = new List<BucketListActivity>();
        }

        [Required]
        public Guid UserId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public ICollection<BucketListActivity> BucketListActivities { get; set; }
        public void AddBucketListActivity(BucketListActivity activity)
        {
            this.BucketListActivities.Add(activity);
        }

        public void RemoveActivity(Guid activityId)
        {
            var activity = this.BucketListActivities.FirstOrDefault(bucketlistactivity => bucketlistactivity.ActivityId == activityId);

            if (activity != null)
            {
                this.BucketListActivities.Remove(activity);
            }
        }

    }
}