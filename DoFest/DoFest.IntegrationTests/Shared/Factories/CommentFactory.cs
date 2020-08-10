using DoFest.Entities.Activities.Content;
using System;

namespace DoFest.IntegrationTests.Shared.Factories
{
    public static class CommentFactory
    {
        public static Comment Default(Guid activityId, Guid userId)
        {
            return new Comment(
                activityId,
                userId,
                "comentariu"
                );
        }
    }
}
