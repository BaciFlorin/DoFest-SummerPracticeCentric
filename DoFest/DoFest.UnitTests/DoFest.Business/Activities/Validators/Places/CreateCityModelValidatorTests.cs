using DoFest.Business.Activities.Validators.Places;
using DoFest.UnitTests.Shared.Extensions;
using DoFest.UnitTests.Shared.Factories;
using FluentAssertions;
using Xunit;

namespace DoFest.UnitTests.DoFest.Business.Activities.Validators.Places
{
    public class CreateCityModelValidatorTests
    {
        [Fact]
        public void GivenValidate_WhenHavingValidInput_ThenResultShouldBeValid()
        {
            var model = CreateCityModelFactory.Default();
            var validator = new CreateCityModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeTrue();
            result.Errors.Count.Should().Be(0);
        }

        [Fact]
        public void GivenValidate_WhenHavingANullName_ThenResultShouldBeInvalid()
        {
            var model = CreateCityModelFactory.Default().WithName(null);
            var validator = new CreateCityModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(2);
        }

        [Fact]
        public void GivenValidate_WhenHavingMoreThan100Name_ThenResultShouldBeInvalid()
        {
            var model = CreateCityModelFactory.Default().WithName(new string('*', 101));
            var validator = new CreateCityModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
        }

        [Fact]
        public void GivenValidate_WhenHavingAnEmptyName_ThenResultShouldBeInvalid()
        {
            var model = CreateCityModelFactory.Default().WithName("");
            var validator = new CreateCityModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
        }
    }
}
