﻿using System;
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
        public Activity() : base()
        {
            Photos = new List<Photo>();
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
            Notes = new List<Note>();
            BucketListActivities = new List<BucketListActivity>();
            Notifications = new List<Notification>();
        }

        [Required] public Guid? ActivityTypeId { get; set; }

        [Required] public Guid? LocationId { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public ICollection<Note> Notes { get; set; }

        [Required, MaxLength(500)] public string Description { get; set; }

        public ICollection<BucketListActivity> BucketListActivities { get; set; }

        public ICollection<Notification> Notifications { get; set; }

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
    }
}