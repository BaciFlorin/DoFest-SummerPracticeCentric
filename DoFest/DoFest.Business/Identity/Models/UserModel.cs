using System;

namespace DoFest.Business.Identity.Models
{
    public sealed class UserModel
    {
        public Guid Id{ get; private set; } 

        public string Username { get; private set; }

        public string Email { get; private set; }

        public string UserType { get; private set; }

        public Guid UserTypeId { get; private set; }

        public Guid StudentId { get; private set; }

        public Guid BucketListId { get; private set; }

        public static UserModel Create(
            Guid id,
            string username,
            string email,
            string userType,
            Guid studentId,
            Guid bucketListId
            )
        {
            return new UserModel
            {
                Id = id,
                Username = username,
                Email = email,
                UserType = userType,
                StudentId = studentId,
                BucketListId = bucketListId
            };
        }

    }
}
