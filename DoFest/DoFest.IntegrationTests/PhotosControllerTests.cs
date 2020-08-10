using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DoFest.Business.Activities.Models.Content.Photos;
using DoFest.Entities.Activities;
using DoFest.Entities.Activities.Content;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DoFest.IntegrationTests
{
    public class PhotosControllerTests: IntegrationTests
    {

        [Fact]
        public async Task GetActivityPhotos()
        {
            //Arrange
            var activityType = new ActivityType("Petrecere Tematica");
            var activity = new Activity(
                activityType.Id,
                CityId,
                "Petrecere anii '20",
                "Adresa locatie",
                "Petrecerea impune un dress-code in stilul anilor '20.");

           var photo = new Photo(activity.Id, AuthenticatedUserId, new byte[1]);

            activity.AddPhoto(photo);

            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.GetAsync($"api/v1/activities/{activity.Id}/photos");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var photos = await response.Content.ReadAsAsync<IList<PhotoModel>>();
            photos.Should().HaveCount(1);

        }

        [Fact]
        public async Task AddPhotoToActivity()
        {
            var activityType = new ActivityType("Petrecere Tematica");
            var activity = new Activity(
                activityType.Id,
                CityId,
                "Petrecere anii '20",
                "Adresa locatie",
                "Petrecerea impune un dress-code in stilul anilor '20.");


            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            var ImageFile = new FormFile(new MemoryStream(
                Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.txt");

            var content = new MultipartFormDataContent();
            /*content.Add("image", ImageFile);*/

            //Act
            var response = await HttpClient.PostAsync($"api/v1/activities/{activity.Id}/photos",
               content );

            //Assert
            response.IsSuccessStatusCode.Should().BeTrue();

            var createdPhotoId = response.Headers.Location.OriginalString;
            Photo existingPhoto = null;
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                var existingActivity = await doFestContext.Activities
                    .Include(entity => entity.Photos)
                    .FirstAsync(entity => entity.Id == activity.Id);

                existingPhoto = existingActivity.Photos.FirstOrDefault();
            });

            existingPhoto.Should().NotBeNull();
            existingPhoto.Id.Should().Be(createdPhotoId);
        }
    }
}
