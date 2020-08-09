using DoFest.Business.Activities.Models.Places;
using FluentValidation;

namespace DoFest.Business.Activities.Validators.Places
{
    public sealed class CreateCityModelValidator: AbstractValidator<CreateCityModel>
    {
        public CreateCityModelValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
