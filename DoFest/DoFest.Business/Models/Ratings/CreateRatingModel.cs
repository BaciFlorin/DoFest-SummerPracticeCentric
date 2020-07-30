using System;
using System.Text.Json.Serialization;

namespace DoFest.Business.Models.Ratings
{
    public class CreateRatingModel
    {
        public int Stars { get; set; }

        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}
