
using DoFest.Business.Identity.Validators;
using DoFest.UnitTests.Shared.Extensions;
using DoFest.UnitTests.Shared.Factories;
using FluentAssertions;
using Xunit;

namespace DoFest.UnitTests.DoFest.Business.Identity.Validators
{
    public class NewPasswordModelValidatorTests
    {
        [Fact]
        public void GivenValidate_WithValidInput_ThenResultShouldBeValid()
        {
            var newPaswordModel = NewPasswordModelFactory.Default();
            var validator = new NewPasswordModelValidator();

            var result = validator.Validate(newPaswordModel);

            result.IsValid.Should().BeTrue();
            result.Errors.Count.Should().Be(0);
        }

        [Fact]
        public void GivenValidate_WithNewPasswordLengthLessThan8_ThenResultShouldBeInvalid()
        {
            var newPaswordModel = NewPasswordModelFactory.Default().WithNewPassword("12");
            var validator = new NewPasswordModelValidator();

            var result = validator.Validate(newPaswordModel);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
        }

        [Fact]
        public void GivenValidate_WithNewPasswordLengthEqualWith8_ThenResultShouldBeValid()
        {
            var newPaswordModel = NewPasswordModelFactory.Default().WithNewPassword("12345678");
            var validator = new NewPasswordModelValidator();

            var result = validator.Validate(newPaswordModel);

            result.IsValid.Should().BeTrue();
            result.Errors.Count.Should().Be(0);
        }

        [Fact]
        public void GivenValidate_WithNewPasswordNull_ThenResultShouldBeInvalid()
        {
            var newPaswordModel = NewPasswordModelFactory.Default().WithNewPassword(null);
            var validator = new NewPasswordModelValidator();

            var result = validator.Validate(newPaswordModel);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
        }
    }
}
