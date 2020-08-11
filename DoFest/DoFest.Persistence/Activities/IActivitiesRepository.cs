using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Entities.Activities;

namespace DoFest.Persistence.Activities
{
    /// <summary>
    /// Repository-ul asociat tabelei Activity.
    /// </summary>
    public interface IActivitiesRepository : IRepository<Activity>
    {
        /// <summary>
        /// Cauta fotografiile asociate unei activitati.
        /// </summary>
        /// <param name="id"> Id-ul activitatii cautate. </param>
        /// <returns> O entitate activity. </returns>
        Task<Activity> GetByIdWithPhotos(Guid id);

        /// <summary>
        /// Cauta rating-urile asociate unei activitati.
        /// </summary>
        /// <param name="id"> Id-ul activitatii cautate. </param>
        /// <returns> O entitate activity. </returns>
        Task<Activity> GetByIdWithRatings(Guid id);
        
        /// <summary>
        /// Cauta comentariile asociate unei activitati.
        /// </summary>
        /// <param name="id"> Id-ul activitatii cautate. </param>
        /// <returns> O entitate activity. </returns>
        Task<Activity> GetByIdWithComments(Guid id);

        Task<IList<Activity>> GetActivityListsWithBucketListActivity();

        Task<Activity> GetByName(string name);

        Task<Activity> GetByIdWithNotifications(Guid activityId);
    }
}
