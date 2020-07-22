using System;
using System.Linq;
using DoFest.Entities.Activities.Content;
using Microsoft.EntityFrameworkCore;

namespace DoFest.Persistence.Comments
{
    public sealed class CommentsRepository: Repository<Comment>, ICommentsRepository
    {
        public CommentsRepository(DoFestContext context) : base(context)
        {

        }

        public IQueryable<Comment> GetComments(Guid activityId)
        {
            return context
                .Comments
                .Where(comment => comment.ActivityId == activityId)
                .Select(comment => comment);
        }

        public async void AddComment(Comment comment)
        {
            await Add(comment);
            await SaveChanges();
        }

        public async void DeleteComment(Guid commentId)
        {
            var result = await context
                .Comments
                .Where(x => x.Id == commentId)
                .FirstOrDefaultAsync();
            Delete(result);
            await SaveChanges();
        }
    }
}
