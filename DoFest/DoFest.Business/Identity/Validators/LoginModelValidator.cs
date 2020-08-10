using DoFest.Business.Identity.Models;
using FluentValidation;

namespace DoFest.Business.Identity.Validators
{
    public class LoginModelValidator:AbstractValidator<LoginModelRequest>
    {
        public LoginModelValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .EmailAddress()
                .MaximumLength(200);

            RuleFor(x => x.Password)
                .NotNull()
                .MinimumLength(8)
                .MaximumLength(60);
        }
    }
}