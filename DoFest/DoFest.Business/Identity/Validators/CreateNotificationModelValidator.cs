using DoFest.Business.Identity.Models.Notifications;
using FluentValidation;

namespace DoFest.Business.Identity.Validators
{
    public class CreateNotificationModelValidator:AbstractValidator<CreateNotificationModel>
    {
        public CreateNotificationModelValidator()
        {
            RuleFor(n => n.Description)
                .NotNull()
                .MaximumLength(1000)
                .NotEmpty();

            RuleFor(n => n.ActivityId)
                .NotNull()
                .NotEmpty();
        }
    }
}