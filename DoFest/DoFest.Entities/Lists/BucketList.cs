using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoFest.Entities.Authentication;

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
    }
}