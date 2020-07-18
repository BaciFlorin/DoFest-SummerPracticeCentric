using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using DoFest.Entities.Activities.Content;

namespace DoFest.Entities.Authentication
{
    [Table("User")]
    public class User:Entity
    {
        public User():base()
        {
            Photos = new List<Photo>();
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
            Notes = new List<Note>();
        }

        [Required, MaxLength(50)]
        public string Username { get;  set; }
        
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get;  set; }

        [Required, DataType(DataType.Password)]
        public string PasswordHash { get;  set; }

        [AllowNull]
        public Guid? UserTypeId { get; set; }
        public UserType Type { get;  set; }

        [AllowNull]
        public Guid? StudentId { get; set; }
        public Student UStudent { get;  set; }

        public ICollection<Photo> Photos { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}