using DoFest.Business.Activities.Validators.BucketList;
using DoFest.UnitTests.Shared.Extensions;
using DoFest.UnitTests.Shared.Factories;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace DoFest.UnitTests.DoFest.Business.Activities.Validators.BucketList
{
    public class BucketListUpdateModelValidatorTests
    {
        [Fact]
        public void GivenValidate_WithValidInput_ThenResultShouldBeValid()
        {
            var bucketModel = BucketListUpdateModelFactory.Default();
            var validator = new BucketListUpdateModelValidator();

            var result = validator.Validate(bucketModel);

            result.IsValid.Should().BeTrue();
            result.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void GivenValidate_WithNullActivitiesForDelete_ThenResultShouldBeInvalid()
        {
            var bucketModel = BucketListUpdateModelFactory.Default().WithActivitiesForDelete(null);
            var validator = new BucketListUpdateModelValidator();

            var result = validator.Validate(bucketModel);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
        }

        [Fact]
        public void GivenValidate_WithNullActivitiesForToggle_ThenResultShouldBeInvalid()
        {
            var bucketModel = BucketListUpdateModelFactory.Default().WithActivitiesForToggle(null);
            var validator = new BucketListUpdateModelValidator();

            var result = validator.Validate(bucketModel);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
        }


        [Fact]
        public void GivenValidate_WithNullBucketListName_ThenResultShouldBeInvalid()
        {
            var bucketModel = BucketListUpdateModelFactory.Default().WithName(null);
            var validator = new BucketListUpdateModelValidator();

            var result = validator.Validate(bucketModel);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
        }

        [Fact]
        public void GivenValidate_WithBucketListNameLenghtLessThan6_ThenResultShouldBeInvalid()
        {
            var bucketModel = BucketListUpdateModelFactory.Default().WithName("12");
            var validator = new BucketListUpdateModelValidator();

            var result = validator.Validate(bucketModel);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
        }

        [Fact]
        public void GivenValidate_WithBucketListNameLenghtEqualWith6_ThenResultShouldBeValid()
        {
            var bucketModel = BucketListUpdateModelFactory.Default().WithName("123456");
            var validator = new BucketListUpdateModelValidator();

            var result = validator.Validate(bucketModel);

            result.IsValid.Should().BeTrue();
            result.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void GivenValidate_WithBucketListNameLenghtMoreThan100_ThenResultShouldBeInvalid()
        {
            var bucketModel = BucketListUpdateModelFactory.Default().WithName(string.Create(101,'8',(a,b)=> a.Fill(b)));
            var validator = new BucketListUpdateModelValidator();

            var result = validator.Validate(bucketModel);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
        }

        [Fact]
        public void GivenValidate_WithBucketListNameLenghtEqualWith100_ThenResultShouldBeValid()
        {
            var bucketModel = BucketListUpdateModelFactory.Default().WithName(string.Create(100, '8', (a, b) => a.Fill(b)));
            var validator = new BucketListUpdateModelValidator();

            var result = validator.Validate(bucketModel);

            result.IsValid.Should().BeTrue();
            result.Errors.Should().HaveCount(0);
        }
    }
}
