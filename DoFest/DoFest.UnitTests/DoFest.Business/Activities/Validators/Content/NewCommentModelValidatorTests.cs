using DoFest.Business.Activities.Validators.Content;
using DoFest.UnitTests.Shared.Extensions;
using DoFest.UnitTests.Shared.Factories;
using FluentAssertions;
using System;
using Xunit;

namespace DoFest.UnitTests.DoFest.Business.Activities.Validators.Content
{
    public class NewCommentModelValidatorTests
    {
        [Fact]
        public void GivenValidate_WhenHavingAValidInput_ThenResultShouldBeValid()
        {
            var model = NewCommentModelFactory.Default();
            var validator = new NewCommentModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeTrue();
            result.Errors.Count.Should().Be(0);
        }

        [Fact]
        public void GivenValidate_WhenHavingAnEmptyContent_ThenResultShouldBeInvalid()
        {
            var model = NewCommentModelFactory.Default().WithContent("");
            var validator = new NewCommentModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
        }

        [Fact]
        public void GivenValidate_WhenHavingANullContent_ThenResultShouldBeInvalid()
        {
            var model = NewCommentModelFactory.Default().WithContent(null);
            var validator = new NewCommentModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void GivenValidate_WhenHavingMoreThan1000Content_ThenResultShouldBeInvalid()
        {
            var model = NewCommentModelFactory.Default().WithContent(new string('*', 1_001));
            var validator = new NewCommentModelValidator();

            var result = validator.Validate(model);

            result.IsValid.Should().BeFalse();
        }
    }
}
