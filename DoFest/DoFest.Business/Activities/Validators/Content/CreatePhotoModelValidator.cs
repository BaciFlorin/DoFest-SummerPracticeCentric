using DoFest.Business.Activities.Models.Content.Photos;
using FluentValidation;

namespace DoFest.Business.Activities.Validators.Content
{
    public class CreatePhotoModelValidator : AbstractValidator<CreatePhotoModel>
    {
        public CreatePhotoModelValidator()
        {
            RuleFor(x => x.Image)
                .NotNull();
        }
    }
}
