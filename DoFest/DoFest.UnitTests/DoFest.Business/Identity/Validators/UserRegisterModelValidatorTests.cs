using DoFest.Business.Identity.Validators;
using Xunit;
using FluentAssertions;
using DoFest.UnitTests.Shared.Factories;

namespace DoFest.UnitTests.DoFest.Business.Identity.Validators
{
    public class UserRegisterModelValidatorTests
    {
        [Fact]
        public void GivenValidate_WhenHavingAValidInput_ThenResultShouldBeValid()
        {
            var model = UserRegisterModelFactory.Default();
            var modelValidator = new UserRegisterModelValidator();

            // modelValidator.ShouldHaveValidationErrorFor( x => x.Password, model);

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeTrue();
            result.Errors.Count.Should().Be(0);
        }

        [Fact]
        public void GivenValidate_WhenHavingANullEmail_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.WithEmailNull();
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingANullUsername_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.WithUsernameNull();
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }
    }
}
