using DoFest.Business.Identity.Models;
using FluentValidation;

namespace DoFest.Business.Identity.Validators
{
    public class NewPasswordModelValidator:AbstractValidator<NewPasswordModelRequest>
    {
        public NewPasswordModelValidator()
        {
            RuleFor(x => x.NewPassword)
                .MinimumLength(8)
                .NotNull()
                .MaximumLength(60);
        }
    }
}