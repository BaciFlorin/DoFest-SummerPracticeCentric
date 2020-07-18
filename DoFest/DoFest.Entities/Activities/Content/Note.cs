using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoFest.Entities.Authentication;

namespace DoFest.Entities.Activities.Content
{
    [Table("Note")]
    public class Note : Entity
    {
        public Note() : base()
        {

        }

        [Required]
        public Guid? ActivityId { get; set; }
        public Activity NActivity { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        public User NUser { get; set; }

        [Required, MaxLength(1000)] 
        public string Content { get; set; }
    }
}