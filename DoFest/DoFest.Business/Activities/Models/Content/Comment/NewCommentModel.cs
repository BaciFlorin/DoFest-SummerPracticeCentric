using System;
using System.Text.Json.Serialization;

namespace DoFest.Business.Activities.Models.Content.Comment
{
    public sealed class NewCommentModel
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public string Content { get; set; }
    }
}
