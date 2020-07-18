using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoFest.Entities.Authentication;

namespace DoFest.Entities.Activities.Content
{
    [Table("Photo")]
    public class Photo:Entity
    {
        public Photo():base()
        {
            
        }

        [Required]
        public Guid? ActivityId { get; set; }
        public Activity PActivity { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        public User PUser { get; set; }

        public byte[] Image { get; set; }
    }
}