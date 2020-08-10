using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using DoFest.Entities;
using DoFest.Entities.Activities.Content;

namespace DoFest.IntegrationTests.Entities
{
    [Table("User")]
    public class FakeUser:Entity
    {
        private FakeUser():base()
        {
 
        }

        public string Username { get;  set; }
        
        public string Email { get;  set; }

        public string PasswordHash { get;  set; }
       
        public Guid UserTypeId { get;  set; }

        public Guid? StudentId { get;  set; }

 
    }
}