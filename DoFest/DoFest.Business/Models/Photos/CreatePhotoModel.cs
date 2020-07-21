using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace DoFest.Business.Models.Photos
{
    public sealed class CreatePhotoModel
    {
       
        public Guid UserId { get; set; }
        public IFormFile Image { get; set; }
    }
}
