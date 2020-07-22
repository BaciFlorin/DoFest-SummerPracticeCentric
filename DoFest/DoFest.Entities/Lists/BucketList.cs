using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Guid? UserId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public ICollection<BucketListActivity> BucketListActivities { get; set; }
        public object Username { get; set; }
    }
}