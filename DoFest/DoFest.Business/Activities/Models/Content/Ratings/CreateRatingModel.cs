using System;

namespace DoFest.Business.Activities.Models.Content.Ratings
{
    public class CreateRatingModel
    {
        public int Stars { get; set; }

        public Guid UserId { get; set; }
    }
}
