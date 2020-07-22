using System;
using System.Collections.Generic;
using System.Text;
using DoFest.Business.Models.Ratings;
using FluentValidation;

namespace DoFest.Business.Validators
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
