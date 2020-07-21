using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DoFest.Entities.Activities.Content;
using DoFest.Entities.Activities.Places;
using DoFest.Entities.Lists;

namespace DoFest.Entities.Activities
{
    [Table("Activity")]
    public class Activity : Entity
    {
        public Activity() : base()
        {
            Photos = new List<Photo>();
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
            Notes = new List<Note>();
            BucketListActivities = new List<BucketListActivity>();
        }

        [Required] public Guid? ActivityTypeId { get; set; }

        [Required] public Guid? LocationId { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public ICollection<Note> Notes { get; set; }

        [Required, MaxLength(500)] public string Description { get; set; }

        public ICollection<BucketListActivity> BucketListActivities { get; set; }

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
    }
}