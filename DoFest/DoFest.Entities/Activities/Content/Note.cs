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
        
        [Required]
        public Guid? UserId { get; set; }

        [Required, MaxLength(250)] 
        public string Content { get; set; }
    }
}