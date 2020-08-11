using DoFest.Business.Activities.Models.BucketList;
using DoFest.Entities.Lists;
using DoFest.IntegrationTests.Shared.Extensions;
using DoFest.IntegrationTests.Shared.Factories;
using DoFest.Persistence;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DoFest.IntegrationTests
{
    public class BucketListsControllerTests : IntegrationTests
    {
        [Fact]
        public async Task GetAllBucketLists()
        {
            //Arrange

            //Act
            var response = await HttpClient.GetAsync($"/api/v1/bucketlists");

            //Assert
            response.IsSuccessStatusCode.Should().BeTrue();

            var bkListName = await response.Content.ReadAsAsync<IList<BucketList>>();
            bkListName.Should().HaveCount(1);
        }

        [Fact]
        public async Task GetBucketListById()
        {
            //Arrange
            var existingBkListId = new Guid();
            await ExecuteDatabaseAction(async (DoFestContext) =>
            {
                var existingBkList = await DoFestContext
                                        .BucketLists
                                        .FirstAsync(entity => entity.UserId == AuthenticatedUserId);

                existingBkListId = existingBkList.Id;
            });

            //Act
            var response = await HttpClient.GetAsync($"/api/v1/bucketlists/{existingBkListId}");

            //Assert
            response.IsSuccessStatusCode.Should().BeTrue();

            var bkList = await response.Content.ReadAsAsync<BucketList>();

            bkList.UserId.Should().Equals(AuthenticatedUserId);
        }

        [Fact]
        public async Task GetBucketListByInvalidId()
        {
            //Arrange
            var existingBkListId = Guid.NewGuid();

            // Act
            var response = await HttpClient.GetAsync($"/api/v1/bucketlists/{existingBkListId}");

            //Assert
            response.IsSuccessStatusCode.Should().BeFalse();
        }

        [Fact]
        public async Task AddActivityInBucketList()
        {
            //Arrange
            var activityType = ActivityTypeFactory.Default();
            var city = CityFactory.Default();
            var activity = ActivityFactory.Default(city.Id, activityType.Id);
            BucketList bucket = null;
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Cities.AddAsync(city);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();

                bucket = await doFestContext
                            .BucketLists
                            .FirstOrDefaultAsync(x => x.UserId == AuthenticatedUserId);

            });

            //Act
            var response = await HttpClient.PostAsync($"/api/v1/bucketlists/{bucket.Id}/activities/{activity.Id}", null);

            //Assert
            response.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task AddNonExistingActivity()
        {
            //Arrange
            BucketList bucket = null;
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                bucket = await doFestContext
                            .BucketLists
                            .FirstOrDefaultAsync(x => x.UserId == AuthenticatedUserId);
            });

            //Act
            var response = await HttpClient.PostAsync($"/api/v1/bucketlists/{bucket.Id}/activities/{new Guid()}", null);

            //Assert
            response.IsSuccessStatusCode.Should().BeFalse();
        }

        [Fact]
        public async Task UpdateBucketList()
        {
            //Arrange
            var activityType = ActivityTypeFactory.Default();
            var city = CityFactory.Default();
            var activity = ActivityFactory.Default(city.Id, activityType.Id);
            BucketList bucket = null;
            var updateModel = new BucketListUpdateModel()
            {
                Name = "bucketlist test",
                ActivitiesForDelete = new List<Guid>(),
                ActivitiesForToggle = new List<Guid>()            
            };
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                bucket = await doFestContext
                            .BucketLists
                            .FirstOrDefaultAsync(x => x.UserId == AuthenticatedUserId);
                await doFestContext.Cities.AddAsync(city);
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
                await doFestContext.BucketListActivities.AddAsync(new BucketListActivity(bucket.Id, activity.Id));
                await doFestContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.PutAsJsonAsync($"/api/v1/bucketlists/{bucket.Id}/activities", updateModel);

            //Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            BucketList existingBucketList = null;
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                existingBucketList = await doFestContext
                            .BucketLists
                            .FirstOrDefaultAsync(x => x.UserId == AuthenticatedUserId);
            });
            existingBucketList.Should().NotBeNull();
            existingBucketList.Name.Should().Be(updateModel.Name);
        }

        [Fact]
        public async Task UpdateInvalidBucketList()
        {
            //Arrange
            Guid bucketId = Guid.NewGuid();
            var updateModel = new BucketListUpdateModel()
            {
                Name = "bucketlist test"
            };

            //Act
            var response = await HttpClient.PutAsJsonAsync($"/api/v1/bucketlists/{bucketId}/activities", updateModel);

            //Assert
            response.IsSuccessStatusCode.Should().BeFalse();
        }
    }

}

