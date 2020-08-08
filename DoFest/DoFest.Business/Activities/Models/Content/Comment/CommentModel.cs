using System;

namespace DoFest.Business.Activities.Models.Content.Comment
{
    /// <summary>
    /// Reprezentarea unei entitati Comment in cod.
    /// </summary>
    public sealed class CommentModel
    {
        public Guid Id { get; private set; }

        public Guid ActivityId { get; private set; }

        public Guid UserId { get; private set; }
        public string Username { get; private set; }

        public string Content { get; private set; }

        public static CommentModel Create(Guid id, Guid activityId, Guid userId, string username, string content)
        {
            return new CommentModel
            {
                Id = id,
                ActivityId = activityId,
                UserId = userId,
                Username = username,
                Content = content
            };
        }
    }
}
