using System;

namespace DoFest.Business.Identity.Models
{
    public sealed class UserModel
    {
        public Guid Id{ get; set; } 
        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string UserType { get; set; }

        public Guid StudentId { get; set; }

    }
}
