
using DoFest.Business.Identity.Validators;
using DoFest.UnitTests.Shared.Extensions;
using DoFest.UnitTests.Shared.Factories;
using FluentAssertions;
using Xunit;

namespace DoFest.UnitTests.DoFest.Business.Identity.Validators
{
    public class LoginModelValidatorTests
    {
        [Fact]
        public void GivenValidate_WhenHavingAValidInput_ThenResultShouldBeValid()
        {
            var loginModel = LoginModelFactory.Default();
            var validator = new LoginModelValidator();

            var result = validator.Validate(loginModel);

            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }

        [Fact]
        public void GivenValidate_WhenHavingANullEmail_ThenResultShouldBeInvalid()
        {
            var loginModel = LoginModelFactory.Default().WithEmail(null);
            var validator = new LoginModelValidator();

            var result = validator.Validate(loginModel);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
        }

        [Fact]
        public void GivenValidate_WhenHavingANullPassword_ThenResultShouldBeInvalid()
        {
            var loginModel = LoginModelFactory.Default().WithPassword(null);
            var validator = new LoginModelValidator();

            var result = validator.Validate(loginModel);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
        }

        [Fact]
        public void GivenValidate_WhenHavingANullPasswordAndEmail_ThenResultShouldBeInvalid()
        {
            var loginModel = LoginModelFactory.Default().WithPassword(null).WithEmail(null);
            var validator = new LoginModelValidator();

            var result = validator.Validate(loginModel);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(2);
        }

        [Fact]
        public void GivenValidate_WhenHavingAnInvalidEmailAdress_ThenResultShouldBeInvalid()
        {
            var loginModel = LoginModelFactory.Default().WithEmail("florin");
            var validator = new LoginModelValidator();

            var result = validator.Validate(loginModel);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
        }

        [Fact]
        public void GivenValidate_WhenHavingPasswordLengthLessThan8_ThenResultShouldBeInvalid()
        {
            var loginModel = LoginModelFactory.Default().WithPassword("parola");
            var validator = new LoginModelValidator();

            var result = validator.Validate(loginModel);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
        }

        [Fact]
        public void GivenValidate_WhenHavingPasswordLengthEqual8_ThenResultShouldBeValid()
        {
            var loginModel = LoginModelFactory.Default().WithPassword("12345678");
            var validator = new LoginModelValidator();

            var result = validator.Validate(loginModel);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void GivenValidate_WhenHavingPasswordLengthMoreThan60_ThenResultShouldBeInvalid()
        {
            var loginModel = LoginModelFactory.Default().WithPassword(string.Create(61,'1',(colector, input)=>colector.Fill(input)));
            var validator = new LoginModelValidator();

            var result = validator.Validate(loginModel);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
        }

        [Fact]
        public void GivenValidate_WhenHavingPasswordLengthEqualWith60_ThenResultShouldBeValid()
        {
            var loginModel = LoginModelFactory.Default().WithPassword(string.Create(60, '1', (colector, input) => colector.Fill(input)));
            var validator = new LoginModelValidator();

            var result = validator.Validate(loginModel);

            result.IsValid.Should().BeTrue();
            result.Errors.Count.Should().Be(0);
        }

        [Fact]
        public void GivenValidate_WhenHavingEmailLengthMoreThan300_ThenResultShouldBeInvalid()
        {
            var loginModel = LoginModelFactory.Default().WithEmail(string.Create(191, '1', (colector, input) => colector.Fill(input)) + "@gmail.com");
            var validator = new LoginModelValidator();

            var result = validator.Validate(loginModel);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
        }

        [Fact]
        public void GivenValidate_WhenHavingEmailLengthEqualWith300_ThenResultShouldBeValid()
        {
            var loginModel = LoginModelFactory.Default().WithEmail(string.Create(190, '1', (colector, input) => colector.Fill(input)) + "@gmail.com");
            var validator = new LoginModelValidator();

            var result = validator.Validate(loginModel);

            result.IsValid.Should().BeTrue();
            result.Errors.Should().HaveCount(0);
        }
    }
}
