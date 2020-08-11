using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoFest.Entities.Activities;
using Microsoft.EntityFrameworkCore;

namespace DoFest.Persistence.Activities
{
   public sealed class ActivitiesRepository : Repository<Activity>, IActivitiesRepository
    {
        public ActivitiesRepository(DoFestContext context) : base(context)
        {
        }

        public async Task<Activity> GetByIdWithPhotos(Guid id)
            => await this.context.Activities
                .Include(activity => activity.Photos)
                .FirstAsync(activity => activity.Id == id);


        public async Task<Activity> GetByIdWithRatings(Guid id)
            => await this.context.Activities
                .Include(activity => activity.Ratings)
                .FirstAsync(activity => activity.Id == id);
        public async Task<Activity> GetByIdWithComments(Guid id)
           => await this.context
               .Activities
               .Include(activity => activity.Comments)
               .FirstAsync(activity => activity.Id == id);
        public async Task<IList<Activity>> GetActivityListsWithBucketListActivity()
             => await context
                .Activities
                .Include(a=>a.BucketListActivities)
                .ToListAsync();

        public async Task<Activity> GetByName(string name)
            => await context
            .Activities.Where(activity => activity.Name == name).FirstOrDefaultAsync();

        public async Task<Activity> GetByIdWithNotifications(Guid activityId)
            => await this.context.Activities
                .Include(activity => activity.Notifications)
                .FirstAsync(activity => activity.Id == activityId);
    }
}
