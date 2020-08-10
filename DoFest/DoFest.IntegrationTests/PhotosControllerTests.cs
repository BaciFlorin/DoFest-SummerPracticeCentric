using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DoFest.Business.Activities.Models.Content.Photos;
using DoFest.Entities.Activities;
using DoFest.Entities.Activities.Content;
using DoFest.IntegrationTests.Shared.Extensions;
using DoFest.IntegrationTests.Shared.Factories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DoFest.IntegrationTests
{
    public class PhotosControllerTests : IntegrationTests
    {

        [Fact]
        public async Task GetActivityPhotos()
        {
            //Arrange
            var activityType = ActivityTypeFactory.Default();
            var activity = ActivityFactory.Default(CityId, activityType.Id);

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
            var activityType = ActivityTypeFactory.Default();
            var activity = ActivityFactory.Default(CityId, activityType.Id);


            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            var formData = new MultipartFormDataContent();
            var imageFile = new StreamContent(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")));
            formData.Add(imageFile, "image", "image.png");

            var response = await HttpClient.PostAsync($"api/v1/activities/{activity.Id}/photos",
                formData);

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

        [Fact]
        public async Task DeletePhotoFromActivity()
        {
            //Arrange
            var activityType = ActivityTypeFactory.Default();
            var activity = ActivityFactory.Default(CityId, activityType.Id);

            var photo = new Photo(activity.Id, AuthenticatedUserId, new byte[1]);

            activity.AddPhoto(photo);

            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.DeleteAsync($"api/v1/activities/{activity.Id}/photos/{photo.Id}");


            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            Activity existingActvity = null;
            Photo existingPhoto = null;
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                existingActvity = await doFestContext
                    .Activities
                    .Include(entity => entity.Photos)
                    .FirstAsync(entity => entity.Id == activity.Id);
                existingPhoto = existingActvity.Photos.FirstOrDefault();
            });
            existingActvity.Photos.Should().HaveCount(0);
            existingPhoto.Should().BeNull();

        }


        [Fact]
        public async Task GetInvalidActivityPhotos()
        {
            //Act
            var response = await HttpClient.GetAsync($"api/v1/activities/{new Guid()}/photos");

            // Assert
            response.IsSuccessStatusCode.Should().BeFalse();
        }


        [Fact]
        public async Task AddPhotoToInvalidActivity()
        {
            //Arrange

            var formData = new MultipartFormDataContent();
            var imageFile = new StreamContent(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")));
            formData.Add(imageFile, "image", "image.png");

            //Act
            var response = await HttpClient.PostAsync($"api/v1/activities/{new Guid()}/photos",
                formData);

            //Assert
            response.IsSuccessStatusCode.Should().BeFalse();
        }


        [Fact]
        public async Task DeleteInvalidPhotoFromActivity()
        {
            //Arrange
            var activityType = ActivityTypeFactory.Default();
            var activity = ActivityFactory.Default(CityId, activityType.Id);


            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.DeleteAsync($"api/v1/activities/{activity.Id}/photos/{new Guid()}");


            // Assert
            response.IsSuccessStatusCode.Should().BeFalse();
          
        }

    }
}
