using System;

namespace DoFest.Business.Models.Content.Comment
{
    public sealed class NewCommentModel
    {
        public Guid? ActivityId { get; set; }
        public Guid? UserId { get; set; }
        public string Content { get; set; }

    }
}
