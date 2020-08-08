using DoFest.Business.Activities.Models.Content.Photos;
using Microsoft.AspNetCore.Http;

namespace DoFest.UnitTests.Shared.Extensions
{
    public static class CreatePhotoModelExtensions
    {
        public static CreatePhotoModel WithImageFile(this CreatePhotoModel model, IFormFile image)
        {
            model.Image = image;
            return model;
        }
    }
}
