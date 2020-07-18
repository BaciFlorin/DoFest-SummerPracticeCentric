using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoFest.Entities.Activities.Content;
using DoFest.Entities.Places;

namespace DoFest.Entities.Activities
{
    [Table("Activity")]
    public class Activity:Entity
    {
        public Activity():base()
        {
            Photos = new List<Photo>();
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
            Notes = new List<Note>();
        }

        [Required]
        public Guid ActivityTypeId { get; set; }
        public ActivityType AcType { get; set; }

        [Required]
        public Guid LocationId { get; set; }
        public Location AcLocation { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public ICollection<Note> Notes { get; set; }

        [Required]
        public string Description { get; set; }
    }
}