using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DoFest.Business.Models.Ratings
{
    public class CreateRatingModel
    {
        public int Stars { get; set; }

        public Guid UserId { get; set; }
    }
}
