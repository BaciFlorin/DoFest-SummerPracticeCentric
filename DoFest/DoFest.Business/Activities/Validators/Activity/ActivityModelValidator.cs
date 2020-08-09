using DoFest.Business.Activities.Models.Activity;
using FluentValidation;

namespace DoFest.Business.Activities.Validators.Activity
{
    public class ActivityModelValidator: AbstractValidator<ActivityModel>
    {
        public ActivityModelValidator()
        {
            RuleFor(x => x.Id)
               .NotNull()
               .NotEmpty();

            RuleFor(x => x.CityId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}
