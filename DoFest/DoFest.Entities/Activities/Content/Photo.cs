using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoFest.Entities.Activities.Content
{
    [Table("Photo")]
    public class Photo:Entity
    {
        private Photo():base()
        {

        }

        public Photo(
            Guid ActivityId,
            Guid UserId,
            byte[] Image
            ):base()
        {
            this.ActivityId = ActivityId;
            this.UserId = UserId;
            this.Image = Image;
        }

        [Required]
        public Guid ActivityId { get; private set; }

        [Required]
        public Guid UserId { get; private set; }

        [Required]
        public byte[] Image { get; private set; }
    }
}