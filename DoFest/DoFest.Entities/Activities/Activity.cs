using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DoFest.Entities.Activities.Content;
using DoFest.Entities.Authentication.Notification;
using DoFest.Entities.Lists;

namespace DoFest.Entities.Activities
{
    [Table("Activity")]
    public class Activity : Entity
    {
        private Activity():base()
        {
            Photos = new List<Photo>();
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
            BucketListActivities = new List<BucketListActivity>();
            Notifications = new List<Notification>();
        }

        public Activity(
            Guid ActivityTypeId,
            Guid CityId,
            string Name,
            string Address,
            string Description
            ) : base()
        {
            this.ActivityTypeId = ActivityTypeId;
            this.CityId = CityId;
            this.Name = Name;
            this.Address = Address;
            this.Description = Description;

            Photos = new List<Photo>();
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
            BucketListActivities = new List<BucketListActivity>();
            Notifications = new List<Notification>();
        }

        [Required] public Guid ActivityTypeId { get; private set; }

        [Required]
        public Guid CityId { get; private set; }

        [Required, MaxLength(200)]
        public string Name { get; private set; }

        [Required, MaxLength(1000)]
        public string Address { get; private set; }

        [Required, MaxLength(2000)] 
        public string Description { get; private set; }

        public ICollection<Photo> Photos { get;  private set; }
        public ICollection<Comment> Comments { get; private set; }

        public ICollection<Rating> Ratings { get; private set; }

        public ICollection<BucketListActivity> BucketListActivities { get; private set; }

        public ICollection<Notification> Notifications { get; private set; }

        public void RemovePhoto(Guid photoId)
        {
            var photo = this.Photos.FirstOrDefault(p => p.Id == photoId);

            if (photo != null)
            {
                this.Photos.Remove(photo);
            }
        }

        public void AddPhoto(Photo photo)
        {
            this.Photos.Add(photo);
        }

        public void AddRating(Rating rating)
        {
            this.Ratings.Add(rating);
        }

        public void RemoveRating(Guid ratingId)
        {
            var rating = this.Ratings.FirstOrDefault(r => r.Id == ratingId);

            if (rating != null)
            {
                this.Ratings.Remove(rating);
            }
        }

        /// <summary>
        /// Adauga un comentariu asociat activitatii.
        /// </summary>
        /// <param name="comment"> O entitate Comment ce va fi adaugata. </param>
        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        /// <summary>
        /// Sterge un comentariu asociat activitatii.
        /// </summary>
        /// <param name="commentId"> Id-ul commentariului ce va fi sters. </param>
        public void RemoveComment(Guid commentId)
        {
            var comment = Comments.FirstOrDefault(comment => comment.Id == commentId);
            if (comment != null)
            {
                Comments.Remove(comment);
            }
        }

        public void AddNotification(Notification notification)
        {
            Notifications.Add(notification);
        }
    }
}