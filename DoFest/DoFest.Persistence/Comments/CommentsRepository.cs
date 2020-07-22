using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoFest.Entities.Activities.Content;
using Microsoft.EntityFrameworkCore;

namespace DoFest.Persistence.Comments
{
    public sealed class CommentsRepository: Repository<Comment>, ICommentsRepository
    {
        public CommentsRepository(DoFestContext context) : base(context)
        {

        }

        public IQueryable<ICollection<Comment>> GetComments(Guid activityId)
        {
           
            /*
                => await context
                    .Activities
                    .Include(activity => activity.Comments)
                    .Where(activity => activity.Id == activityId)
                    .ToListAsync();
            */
            return context.Activities
                .Include(activity => activity.Id == activityId)
                .Select(activity => activity.Comments);
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
