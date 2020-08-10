using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoFest.Entities.Activities.Content
{
    [Table("Rating")]
    public class Rating : Entity
    {
        private Rating():base()
        { 
        }

        public Rating(
            Guid ActivityId,
            Guid UserId,
            int Stars
            ) : base()
        {
            this.ActivityId = ActivityId;
            this.UserId = UserId;
            this.Stars = Stars;
        }

        [Required]
        public Guid ActivityId { get; private set; }

        [Required]
        public Guid UserId { get; private set; }

        [Required, Range(0,5)] 
        public int Stars { get; private set; }
    }
}