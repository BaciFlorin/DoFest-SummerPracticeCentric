using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using DoFest.Entities.Activities;

namespace DoFest.Entities.Places
{
    [Table("Location")]
    public class Location:Entity
    {
        public Location():base()
        {
            Activities = new List<Activity>();
        }

        [AllowNull]
        public byte[] Image { get; set; }

        [Required, MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public Guid CityId { get; set; }
        public City LCity { get; set; }

        [Required, MaxLength(300)]
        public string Address { get; set; }

        public ICollection<Activity> Activities { get; set; }
    }
}