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
                .EmailAddress()
                .MaximumLength(200);

            RuleFor(x => x.Password)
                .MinimumLength(8)
                .MaximumLength(60)
                .NotNull();

            RuleFor(x => x.Name)
                .MaximumLength(150)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Username)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(50);

            RuleFor(x => x.Age)
                .Must(a => a >= 18 && a < 99);

            RuleFor(x => x.Year)
                .Must(y => y > 0 && y <= 6);

            RuleFor(x => x.City)
                .NotEmpty();

            RuleFor(x => x.BucketListName)
                .NotNull()
                .MinimumLength(6)
                .MaximumLength(100);

        }
    }
}