using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoFest.Entities.Authentication;

namespace DoFest.Entities.Activities.Content
{
    [Table("Comment")]
    public class Comment:Entity
    {
        public Comment():base()
        {
            
        }

        [Required]
        public Guid? ActivityId { get; set; }
        public Activity Activity { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        public User User { get; set; }

        [Required, MaxLength(1000)]
        public string Content { get; set; }
    }
}