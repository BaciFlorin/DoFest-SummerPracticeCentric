using System;

namespace DoFest.Business.Identity.Models
{
    public sealed class UserModel
    {
        public UserModel(Guid id, string username, string email, string userType, Guid studentId)
        {
            Id = id;
            Username = username;
            Email = email;
            UserType = userType;
            StudentId = studentId;
        }

        public Guid Id{ get; private set; } 
        public string Username { get; private set; }

        public string Email { get; private set; }

        public string UserType { get; private set; }

        public Guid StudentId { get; private set; }

    }
}
