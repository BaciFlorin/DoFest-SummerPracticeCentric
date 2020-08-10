using DoFest.Business.Identity.Validators;
using Xunit;
using FluentAssertions;
using DoFest.UnitTests.Shared.Factories;
using DoFest.UnitTests.Shared.Extensions;
using System;

namespace DoFest.UnitTests.DoFest.Business.Identity.Validators
{
    public class UserRegisterModelValidatorTests
    {
        [Fact]
        public void GivenValidate_WhenHavingAValidInput_ThenResultShouldBeValid()
        {
            var model = UserRegisterModelFactory.Default();
            var modelValidator = new UserRegisterModelValidator();

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
        public void GivenValidate_WhenHavingAInValidEmail_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.Default().WithEmail("florin");
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingAnEmailLenghtMoreThan200_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.Default().WithEmail(string.Create(191,'1',(a,b)=>a.Fill(b))+"@gmail.com");
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingAnEmailLenghtEqualWith200_ThenResultShouldBeValid()
        {
            var model = UserRegisterModelFactory.Default().WithEmail(string.Create(190, '1', (a, b) => a.Fill(b)) + "@gmail.com");
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void GivenValidate_WhenHavingAnPasswordLenghtMoreThan60_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.Default().WithPassword(string.Create(61, '1', (a, b) => a.Fill(b)));
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingAnPasswordLenghtEqualWith60_ThenResultShouldBeValid()
        {
            var model = UserRegisterModelFactory.Default().WithPassword(string.Create(60, '1', (a, b) => a.Fill(b)));
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void GivenValidate_WhenHavingAnPasswordLenghtLessThan8_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.Default().WithPassword(string.Create(2, '1', (a, b) => a.Fill(b)));
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingAnPasswordLenghtEqualWith8_ThenResultShouldBeValid()
        {
            var model = UserRegisterModelFactory.Default().WithPassword(string.Create(8, '1', (a, b) => a.Fill(b)));
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void GivenValidate_WhenHavingANullPassword_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.Default().WithPassword(null);
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingANameLenghtMoreThan150_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.Default().WithName(string.Create(151, '1', (a, b) => a.Fill(b)));
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingANameLenghtEqualWith150_ThenResultShouldBeValid()
        {
            var model = UserRegisterModelFactory.Default().WithName(string.Create(150, '1', (a, b) => a.Fill(b)));
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void GivenValidate_WhenHavingAnEmptyName_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.Default().WithName(string.Empty);
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingANullName_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.Default().WithName(null);
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

        [Fact]
        public void GivenValidate_WhenHavingAnEmptyUsername_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.Default().WithUsername(string.Empty);
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);
       
            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingUsernameLenghtLessThan6_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.Default().WithUsername("1");
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingUsernameLenghtEqualWith6_ThenResultShouldBeValid()
        {
            var model = UserRegisterModelFactory.Default().WithUsername("123456");
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void GivenValidate_WhenHavingUsernameLenghtMoreThan50_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.Default().WithUsername(string.Create(51, '1', (a, b) => a.Fill(b)));
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingUsernameLenghtEqualWith50_ThenResultShouldBeValid()
        {
            var model = UserRegisterModelFactory.Default().WithUsername(string.Create(50, '1', (a, b) => a.Fill(b)));
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void GivenValidate_WhenHavingAgeLessThan18_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.Default().WithAge(17);
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingAgeEqualWith18_ThenResultShouldBeValid()
        {
            var model = UserRegisterModelFactory.Default().WithAge(18);
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void GivenValidate_WhenHavingAgeMoreThan99_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.Default().WithAge(100);
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingAgeEqualWith99_ThenResultShouldBeValid()
        {
            var model = UserRegisterModelFactory.Default().WithAge(99);
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingYearLessThan1_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.Default().WithYear(0);
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingYearEqualWith1_ThenResultShouldBeValid()
        {
            var model = UserRegisterModelFactory.Default().WithYear(1);
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void GivenValidate_WhenHavingYearMoreThan6_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.Default().WithYear(7);
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingYearEqualWith6_ThenResultShouldBeValid()
        {
            var model = UserRegisterModelFactory.Default().WithYear(6);
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void GivenValidate_WhenHavingAnEmptyCity_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.Default().WithCity(Guid.Empty);
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingANullBucketListName_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.Default().WithBucketListName(null);
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingBucketListNameLenghtLessThan6_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.Default().WithBucketListName("1");
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingBucketListNameLenghEqual6_ThenResultShouldBeValid()
        {
            var model = UserRegisterModelFactory.Default().WithBucketListName("123456");
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void GivenValidate_WhenHavingBucketListLengthMoreThan100_ThenResultShouldBeInvalid()
        {
            var model = UserRegisterModelFactory.Default().WithBucketListName(string.Create(101, '1', (a, b) => a.Fill(b)));
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingBucketListLengthEqualWith100_ThenResultShouldBeValid()
        {
            var model = UserRegisterModelFactory.Default().WithBucketListName(string.Create(100, '1', (a, b) => a.Fill(b)));
            var modelValidator = new UserRegisterModelValidator();

            var result = modelValidator.Validate(model);

            result.IsValid.Should().BeTrue();
        }
    }
}
