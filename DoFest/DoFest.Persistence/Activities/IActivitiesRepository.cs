using System;
using System.Threading.Tasks;
using DoFest.Entities.Activities;

namespace DoFest.Persistence.Activities
{
    public interface IActivitiesRepository : IRepository<Activity>
    {
        Task<Activity> GetByIdWithPhotos(Guid id);
        Task<Activity> GetByIdWithRatings(Guid id);
        
        /// <summary>
        /// Cauta comentariile asociate unei activitati.
        /// </summary>
        /// <param name="id"> Id-ul activitatii cautate. </param>
        /// <returns> O entitate activity. </returns>
        Task<Activity> GetByIdWithComments(Guid id);
    }
}
