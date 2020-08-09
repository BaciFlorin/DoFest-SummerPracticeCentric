

using System;
using DoFest.Business.Activities.Models.Content.Ratings;
using DoFest.UnitTests.Shared.Extensions;

namespace DoFest.UnitTests.Shared.Factories
{
    public static class CreateRatingModelFactory
    {
        public static CreateRatingModel Default()
        {
            return new CreateRatingModel()
            {
                Stars=5,
                UserId = Guid.NewGuid()
            };
        }
        public static CreateRatingModel WithStarsOutOfRange()
        {
            return Default().WithStars(6);
        }
    }
}
