using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoFest.Entities.Activities.Content
{
    [Table("Photo")]
    public class Photo:Entity
    {
        public Photo():base()
        {
            
        }

        [Required]
        public Guid ActivityId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public byte[] Image { get; set; }
    }
}