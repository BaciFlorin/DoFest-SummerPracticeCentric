using DoFest.Business.Activities.Validators.Content;
using DoFest.UnitTests.Shared.Factories;
using FluentAssertions;
using Xunit;

namespace DoFest.UnitTests.DoFest.Business.Activities.Validators.Content
{
    public class CreateRatingModelValidatorTests
    {
        [Fact]
        public void GivenValidate_WhenHavingAValidInput_ThenResultShouldBeValid()
        {
            var model = CreateRatingModelFactory.Default();
            var validator = new CreateRatingModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeTrue();
            result.Errors.Count.Should().Be(0);
        }

        [Fact]
        public void GivenValidate_WhenHavingAnOutOfRangeStars_ThenResultShouldBeInvalid()
        {
            var model = CreateRatingModelFactory.WithStarsOutOfRange();
            var validator = new CreateRatingModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
        }
    }
}
