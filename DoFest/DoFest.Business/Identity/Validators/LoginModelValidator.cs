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
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotNull()
                .MinimumLength(8);
        }
    }
}