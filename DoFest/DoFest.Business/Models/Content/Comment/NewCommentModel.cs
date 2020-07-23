using System;

namespace DoFest.Business.Models.Content.Comment
{
    /// <summary>
    /// Model de data prin care se adauga un comentariu nou.
    /// </summary>
    public sealed class NewCommentModel
    {
        public Guid? UserId { get; set; }
        public string Content { get; set; }

    }
}
