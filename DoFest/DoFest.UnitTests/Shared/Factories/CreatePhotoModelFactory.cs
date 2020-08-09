using System;
using System.IO;
using System.Text;
using DoFest.Business.Activities.Models.Content.Photos;
using DoFest.UnitTests.Shared.Extensions;
using Microsoft.AspNetCore.Http.Internal;

namespace DoFest.UnitTests.Shared.Factories
{

    public static class CreatePhotoModelFactory
    {
        public static CreatePhotoModel Default()
        {
            return new CreatePhotoModel()
            {
              Image= new FormFile(new MemoryStream(
                      Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.txt"),
               UserId = Guid.NewGuid()
            };
        }

        public static CreatePhotoModel WithImageNull()
        {
            return Default().WithImageFile(null);
        }
    }
}
