using DoFest.Business.Activities.Models.Content.Ratings;
using FluentValidation;

namespace DoFest.Business.Activities.Validators.Content
{
    public class CreateRatingModelValidator:AbstractValidator<CreateRatingModel>
    {
        public CreateRatingModelValidator()
        {
            RuleFor(x => x.Stars)
                .InclusiveBetween(1, 5);
        }
    }
}
