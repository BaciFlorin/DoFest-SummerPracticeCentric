using System;
using Microsoft.AspNetCore.Http;

namespace DoFest.Business.Activities.Models.Content.Photos
{
    public sealed class CreatePhotoModel
    {
       
        public Guid UserId { get; set; }
        public IFormFile Image { get; set; }
    }
}
