using DoFest.Business.Identity.Models;
using DoFest.UnitTests.Shared.Extensions;
using System;

namespace DoFest.UnitTests.Shared.Factories
{
    public static class UserRegisterModelFactory
    {
        public static RegisterModel Default()
        {
            return new RegisterModel()
            {
                Email = "abc@test.test",
                City = Guid.NewGuid(),
                BucketListName = "abc abc",
                Age = 20,
                Year = 3,
                Name = "Gigel Andrei",
                Password = "sdadadasadad",
                Username = "gigel123"
            };
        }

        public static RegisterModel WithEmailNull()
        {
            return Default().WithEmail(null);
        }

        public static RegisterModel WithUsernameNull()
        {
            return Default().WithUsername(null);
        }
    }
}
