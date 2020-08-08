using DoFest.Business.Activities.Models.Content.Comment;
using System;

namespace DoFest.UnitTests.Shared.Factories
{
    public static class NewCommentModelFactory
    {
        public static NewCommentModel Default()
        {
            return new NewCommentModel
            {
                Content = "primul comentariu",
                UserId = Guid.NewGuid()
            };
        }
    }
}
