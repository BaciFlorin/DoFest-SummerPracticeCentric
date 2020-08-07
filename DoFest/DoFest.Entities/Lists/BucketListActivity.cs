﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoFest.Entities.Lists
{
    [Table("BucketListActivity")]
    public class BucketListActivity
    {
        public BucketListActivity()
        {
            
        }

        [Required]
        public Guid BucketListId { get; set; }

        [Required]
        public Guid ActivityId { get; set; }

        [DefaultValue("On hold")]
        public string Status { get; set; }

        public void UpdateStatus()
        {
            Status = Status == "Completed" ? "On hold" : "Completed";
        }
    }
}