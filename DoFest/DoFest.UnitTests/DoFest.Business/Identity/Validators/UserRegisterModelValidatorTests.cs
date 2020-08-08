using DoFest.Business.Identity.Validators;
using DoFest.Business.Identity.Models;
using Xunit;
using System;
using FluentValidation.TestHelper;

namespace DoFest.UnitTests.DoFest.Business.Identity.Validators
{
    public class UserRegisterModelValidatorTests
    {
        [Fact]
        public void InvalidPassword_RegisterModel_Test()
        {
            var model = new RegisterModel()
            {
                Email = "abc@test.test",
                City = Guid.NewGuid(),
                BucketListName = "12313",
                Age = 20,
                Year = 3,
                Name = "Gigel Andrei",
                Password = "sdadada",
                Username = "gigel123"
            };
            var modelValidator = new UserRegisterModelValidator();

            modelValidator.ShouldHaveValidationErrorFor( x => x.Password, model);
        }
    }
}
