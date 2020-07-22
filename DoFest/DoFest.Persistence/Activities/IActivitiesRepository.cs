using System;
using System.Threading.Tasks;
using DoFest.Entities.Activities;

namespace DoFest.Persistence.Activities
{
    public interface IActivitiesRepository : IRepository<Activity>
    {
        Task<Activity> GetByIdWithPhotos(Guid id);
        Task<Activity> GetByIdWithRatings(Guid id);

    }
}
