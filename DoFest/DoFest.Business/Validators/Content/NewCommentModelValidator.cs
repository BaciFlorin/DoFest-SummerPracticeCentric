using DoFest.Business.Models.Content.Comment;
using FluentValidation;

namespace DoFest.Business.Validators.Content
{
    /// <summary>
    /// Validatorul asociat modelului business pentru comentarii noi.
    /// </summary>
    public sealed class NewCommentModelValidator: AbstractValidator<NewCommentModel>
    {
        public NewCommentModelValidator()
        {
            RuleFor(x => x.Content)
                .NotNull()
                .NotEmpty();
        }
    }
}
