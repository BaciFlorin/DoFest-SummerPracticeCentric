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
        private User():base()
        {
            Photos = new List<Photo>();
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
        }

        public User(
            string Username,
            string Email,
            string PasswordHash,
            Guid UserTypeId,
            Guid? StudentId
            ) : base()
        {
            this.Username = Username;
            this.Email = Email;
            this.PasswordHash = PasswordHash;
            this.UserTypeId = UserTypeId;
            this.StudentId = StudentId;
            Photos = new List<Photo>();
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
        }

        [Required, MaxLength(50), MinLength(6)]
        public string Username { get; private set; }
        
        [Required, DataType(DataType.EmailAddress), MaxLength(200)]
        public string Email { get; private set; }

        [Required, DataType(DataType.Password)]
        public string PasswordHash { get; private set; }

        [Required]
        public Guid UserTypeId { get; private set; }

        [AllowNull]
        public Guid? StudentId { get; private set; }
        public Student Student { get; private set; }

        public ICollection<Photo> Photos { get; private set; }

        public ICollection<Comment> Comments { get; private set; }

        public ICollection<Rating> Ratings { get; private set; }

        public void AddStudent(Student student)
            => this.Student = student;

        public void UpdatePassword(string password)
            => this.PasswordHash = password;

        public void UpdateUserType(Guid userTypeId)
            => this.UserTypeId = userTypeId;
    }
}