using System;
using System.Text.Json.Serialization;

namespace DoFest.Business.Models.Content.Comment
{
    /// <summary>
    /// Model de data prin care se adauga un comentariu nou.
    /// </summary>
    public sealed class NewCommentModel
    {
        [JsonIgnore]
        public Guid? UserId { get; set; }
        public string Content { get; set; }

    }
}
