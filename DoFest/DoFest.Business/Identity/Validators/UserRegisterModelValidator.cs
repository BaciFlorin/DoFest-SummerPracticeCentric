using DoFest.Business.Identity.Models;
using FluentValidation;

namespace DoFest.Business.Identity.Validators
{
    public class UserRegisterModelValidator:AbstractValidator<RegisterModel>
    {
        public UserRegisterModelValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(8)
                .NotNull();

            RuleFor(x => x.Name)
                .NotNull();

            RuleFor(x => x.Username)
                .NotNull();

            RuleFor(x => x.UserType)
                .NotNull();

            RuleFor(x => x.Age)
                .NotNull()
                .Must(a => a > 0 && a < 99);

            RuleFor(x => x.Year)
                .NotNull()
                .Must(y => y > 0 && y <= 6);

            RuleFor(x => x.City)
                .NotNull();
        }
    }
}