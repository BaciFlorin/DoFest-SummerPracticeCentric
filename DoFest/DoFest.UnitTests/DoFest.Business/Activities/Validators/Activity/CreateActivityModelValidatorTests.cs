using DoFest.Business.Activities.Validators.Activity;
using DoFest.UnitTests.Shared.Extensions;
using DoFest.UnitTests.Shared.Factories;
using FluentAssertions;
using System;
using Xunit;

namespace DoFest.UnitTests.DoFest.Business.Activities.Validators.Activity
{
    public class CreateActivityModelValidatorTests
    {
        [Fact]
        public void GivenValidate_WhenHavingAValidInput_ThenResultShouldBeValid()
        {
            var model = CreateActivityModelFactory.Default();
            var validator = new CreateActivityModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeTrue();
            result.Errors.Count.Should().Be(0);
        }

        [Fact]
        public void GivenValidate_WhenHavingAnEmptyActivityTypeId_ThenResultShouldBeInvalid()
        {
            var model = CreateActivityModelFactory.Default().WithActivityType(Guid.Empty);
            var validator = new CreateActivityModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
        }

        [Fact]
        public void GivenValidate_WhenHavingAnEmptyCityId_ThenResultShouldBeInvalid()
        {
            var model = CreateActivityModelFactory.Default().WithCityId(Guid.Empty);
            var validator = new CreateActivityModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
        }

        [Fact]
        public void GivenValidate_WhenHavingMoreThan200LongName_ThenResultShouldBeInvalid()
        {
            var model = CreateActivityModelFactory.Default().WithName(new string('*', 201));
            var validator = new CreateActivityModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
        }

        [Fact]
        public void GivenValidate_WhenHavingMoreThan2000LongDescription_ThenResultShouldBeInvalid()
        {
            var model = CreateActivityModelFactory.Default().WithDescription(new string('*', 2001));
            var validator = new CreateActivityModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
        }

        [Fact]
        public void GivenValidate_WhenHavingMoreThan1000LongAddress_ThenResultShouldBeInvalid()
        {
            var model = CreateActivityModelFactory.Default().WithAddress(new string('*', 1001));
            var validator = new CreateActivityModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
        }
    }
}
