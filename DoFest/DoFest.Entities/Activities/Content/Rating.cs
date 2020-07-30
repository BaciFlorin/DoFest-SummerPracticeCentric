using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoFest.Entities.Activities.Content
{
    [Table("Rating")]
    public class Rating : Entity
    {
        public Rating() : base()
        {

        }

        [Required]
        public Guid ActivityId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required, Range(0,5)] 
        public int Stars { get; set; }
    }
}