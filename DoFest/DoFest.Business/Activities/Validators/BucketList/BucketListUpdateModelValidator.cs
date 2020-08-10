using DoFest.Business.Activities.Models.BucketList;
using FluentValidation;
using System.Data;

namespace DoFest.Business.Activities.Validators.BucketList
{
    public class BucketListUpdateModelValidator: AbstractValidator<BucketListUpdateModel>
    {
        public BucketListUpdateModelValidator()
        {
            RuleFor(bl => bl.ActivitiesForDelete)
                .NotNull();

            RuleFor(bl => bl.ActivitiesForToggle)
                .NotNull();

            RuleFor(bl => bl.Name)
                .NotNull()
                .MinimumLength(6)
                .MaximumLength(100);
        }
    }
}
