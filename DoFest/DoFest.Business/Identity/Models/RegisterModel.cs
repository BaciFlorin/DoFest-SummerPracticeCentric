using System;

namespace DoFest.Business.Identity.Models
{
    public sealed class RegisterModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Year { get; set; }
        public Guid City { get; set; }
        public string BucketListName { get; set; }
    }
}
