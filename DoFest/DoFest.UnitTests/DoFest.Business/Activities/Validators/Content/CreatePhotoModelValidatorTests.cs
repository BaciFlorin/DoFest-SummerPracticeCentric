using DoFest.Business.Activities.Validators.Content;
using DoFest.UnitTests.Shared.Factories;
using FluentAssertions;
using Xunit;

namespace DoFest.UnitTests.DoFest.Business.Activities.Validators.Content
{

    public class CreatePhotoModelValidatorTests
    {
        [Fact]
        public void GivenValidate_WhenHavingAValidInput_ThenResultShouldBeValid()
        {
            var model = CreatePhotoModelFactory.Default();
            var validator = new CreatePhotoModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeTrue();
            result.Errors.Count.Should().Be(0);
        }

        [Fact]
        public void GivenValidate_WhenHavingANullImage_ThenResultShouldBeInvalid()
        {
            var model = CreatePhotoModelFactory.WithImageNull();
            var validator = new CreatePhotoModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
        }

    }
}
