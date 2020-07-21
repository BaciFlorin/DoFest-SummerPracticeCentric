using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
