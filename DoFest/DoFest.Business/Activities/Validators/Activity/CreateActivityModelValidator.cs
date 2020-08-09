using DoFest.Business.Activities.Models.Activity;
using FluentValidation;

namespace DoFest.Business.Activities.Validators.Activity
{
    public class CreateActivityModelValidator: AbstractValidator<CreateActivityModel>
    {
        public CreateActivityModelValidator()
        {
            RuleFor(x => x.ActivityTypeId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.CityId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotNull()
                .MaximumLength(200);

            RuleFor(x => x.Address)
                .NotNull()
                .MaximumLength(1000);

            RuleFor(x => x.Description)
                .NotNull()
                .MaximumLength(2000);
        }
    }
}
