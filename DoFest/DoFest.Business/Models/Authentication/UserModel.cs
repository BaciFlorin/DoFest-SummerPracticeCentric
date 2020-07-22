using System;

namespace DoFest.Business.Models.Authentication
{
    public sealed class UserModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public Guid? UserTypeId { get; set; }

        public Guid? StudentId { get; set; }

    }
}
