using DoFest.Business.Activities.Models.Activity.ActivityType;
using FluentValidation;

namespace DoFest.Business.Activities.Validators.Activity.ActivityType
{
    public class CreateActivityTypeModelValidator: AbstractValidator<CreateActivityTypeModel>
    {
        public CreateActivityTypeModelValidator()
        {
            RuleFor(x => x.Name)
               .NotNull()
               .NotEmpty()
               .MaximumLength(50);
        }
    }
}
