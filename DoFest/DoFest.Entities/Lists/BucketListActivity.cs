using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoFest.Entities.Lists
{
    [Table("BucketListActivity")]
    public class BucketListActivity
    {
        private BucketListActivity():base()
        {

        }

        public BucketListActivity(
            Guid BucketListId,
            Guid ActivityId
        )
        {
            this.BucketListId = BucketListId;
            this.ActivityId = ActivityId;
            this.Status = "On hold";
        }

        [Required]
        public Guid BucketListId { get; private set; }

        [Required]
        public Guid ActivityId { get; private set; }

        [DefaultValue("On hold")]
        public string Status { get; private set; }

        public void UpdateStatus()
        {
            Status = Status == "Completed" ? "On hold" : "Completed";
        }
    }
}