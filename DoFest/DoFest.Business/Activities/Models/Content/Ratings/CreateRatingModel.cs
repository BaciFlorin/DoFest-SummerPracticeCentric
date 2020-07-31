using System;
using System.Text.Json.Serialization;

namespace DoFest.Business.Activities.Models.Content.Ratings
{
    public class CreateRatingModel
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public int Stars { get; set; }
    }
}
