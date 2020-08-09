using DoFest.Business.Activities.Models.Content.Ratings;

namespace DoFest.UnitTests.Shared.Extensions
{
    public static class CreateRatingModelExtensions
    {
        public static CreateRatingModel WithStars(this CreateRatingModel model, int stars)
        {
            model.Stars = stars;
            return model;
        }
    }
}
