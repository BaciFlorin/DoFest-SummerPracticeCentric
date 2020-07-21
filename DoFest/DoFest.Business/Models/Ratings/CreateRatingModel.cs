using System;
using System.Collections.Generic;
using System.Text;

namespace DoFest.Business.Models.Ratings
{
    public class CreateRatingModel
    {
        public Guid UserId { get; set; }

        public int Stars { get; set; }
    }
}
