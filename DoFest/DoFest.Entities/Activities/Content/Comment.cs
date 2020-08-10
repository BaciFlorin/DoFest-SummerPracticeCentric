using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoFest.Entities.Activities.Content
{
    [Table("Comment")]
    public class Comment:Entity
    {
        private Comment():base()
        {
            
        }

        public Comment(
            Guid ActivityId,
            Guid UserId,
            string content
            ) : base()
        {
            this.ActivityId = ActivityId;
            this.UserId = UserId;
            this.Content = content;
        }

        [Required]
        public Guid ActivityId { get; private set; }

        [Required]
        public Guid UserId { get; private set; }

        [Required, MaxLength(1000)]
        public string Content { get; private set; }
    }
}