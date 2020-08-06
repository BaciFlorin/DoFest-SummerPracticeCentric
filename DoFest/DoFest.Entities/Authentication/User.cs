﻿using System;
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
        private string v1;
        private string v2;

        public User():base()
        {
            Photos = new List<Photo>();
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
        }

        public User(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        [Required, MaxLength(50)]
        public string Username { get;  set; }
        
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get;  set; }

        [Required, DataType(DataType.Password)]
        public string PasswordHash { get;  set; }

        [Required]
        public Guid UserTypeId { get; set; }

        [AllowNull]
        public Guid? StudentId { get; set; }
        public Student Student { get; private set; }

        public ICollection<Photo> Photos { get; private set; }

        public ICollection<Comment> Comments { get; private set; }

        public ICollection<Rating> Ratings { get; private set; }

        public void AddStudent(Student student)
        {
            Student = student;
        }

    }
}