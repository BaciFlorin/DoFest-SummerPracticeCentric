using DoFest.Business.Activities.Models.Content.Comment;
using System;

namespace DoFest.UnitTests.Shared.Extensions
{
    public static class NewCommentModelExtensions
    {
        public static NewCommentModel WithUserId(this NewCommentModel model, Guid userId)
        {
            model.UserId = userId;
            return model;
        }

        public static NewCommentModel WithContent(this NewCommentModel model, string content)
        {
            model.Content = content;
            return model;
        }
    }
}
