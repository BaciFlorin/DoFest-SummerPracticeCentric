using System;

namespace DoFest.Business.Activities.Models.Content.Comment
{
    public sealed class NewCommentModel
    {
        public Guid UserId { get; set; }
        public string Content { get; set; }
    }
}
