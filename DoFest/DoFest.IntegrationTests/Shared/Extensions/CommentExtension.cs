using DoFest.Entities.Activities.Content;
using System;

namespace DoFest.IntegrationTests.Shared.Extensions
{
    public static class CommentExtension
    {
        public static Comment WithActivityId(this Comment commentEntity, Guid activityId)
        {
            return new Comment(
                activityId,
                commentEntity.UserId,
                commentEntity.Content
                );
        }

        public static Comment WithUserId(this Comment commentEntity, Guid userId)
        {
            return new Comment(
                commentEntity.ActivityId,
                userId,
                commentEntity.Content
                );
        }

        public static Comment WithContent(this Comment commentEntity, string content)
        {
            return new Comment(
                commentEntity.ActivityId,
                commentEntity.UserId,
                content
                );
        }
    }
}
