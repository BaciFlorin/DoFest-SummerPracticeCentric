using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Markup;
using DoFest.Entities.Activities;

namespace DoFest.Entities.Lists
{
    [Table("BucketListActivity")]
    public class BucketListActivity
    {
        public BucketListActivity()
        {
            
        }

        [Required]
        public Guid? BucketListId { get; set; }
        public BucketList BucketList { get; set; }

        [Required]
        public Guid? ActivityId { get; set; }
        public Activity Activity { get; set; }

        [DefaultValue("Unlisted")]
        public string Status { get; set; }
    }
}