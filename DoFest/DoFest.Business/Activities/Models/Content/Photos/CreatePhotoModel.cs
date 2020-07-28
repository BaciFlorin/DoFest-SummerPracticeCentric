using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace DoFest.Business.Activities.Models.Content.Photos
{
    public sealed class CreatePhotoModel
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public IFormFile Image { get; set; }
    }
}
