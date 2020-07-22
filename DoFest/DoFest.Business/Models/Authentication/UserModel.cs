using System;
using System.Collections.Generic;
using DoFest.Entities.Activities.Content;
using DoFest.Entities.Authentication.Notification;
using DoFest.Entities.Lists;

namespace DoFest.Business.Models.Authentication
{
    public sealed class UserModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public Guid? UserTypeId { get; set; }

        public Guid? StudentId { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public ICollection<Note> Notes { get; set; }

        public BucketList BucketList { get; set; }

        public ICollection<Notification> Notifications { get; set; }
    }
}
