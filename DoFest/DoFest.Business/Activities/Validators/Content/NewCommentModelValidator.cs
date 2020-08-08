using DoFest.Business.Activities.Models.Content.Comment;
using FluentValidation;

namespace DoFest.Business.Activities.Validators.Content
{
    /// <summary>
    /// Validatorul asociat modelului business pentru comentarii noi.
    /// </summary>
    public sealed class NewCommentModelValidator: AbstractValidator<NewCommentModel>
    {
        public NewCommentModelValidator()
        {
            RuleFor(x => x.Content)
                .MaximumLength(1_000)
                .NotNull()
                .NotEmpty();
        }
    }
}
