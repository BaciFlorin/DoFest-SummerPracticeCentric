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

            //Act
            await ExecuteDatabaseAction(async (DoFestContext) =>
            {
                var existingBkList = await DoFestContext
                                        .BucketLists
                                        .FirstAsync(entity => entity.UserId == AuthenticatedUserId);

                existingBkListId = existingBkList.Id;
            });

            var response = await HttpClient.GetAsync($"/api/v1/bucketlists/{existingBkListId}");

            //Assert
            response.IsSuccessStatusCode.Should().BeTrue();

            var bkList = await response.Content.ReadAsAsync<BucketList>();

            bkList.UserId.Should().Equals(AuthenticatedUserId);
        }

        [Fact]
        public async Task AddActivityInBucketList()
        {
            //Arrange
            var activityType = ActivityTypeFactory.Default();
            var city = CityFactory.Default();
            var activity = ActivityFactory.Default(city.Id, activityType.Id);
            BucketList bucket = null;

            //Act
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

            var response = await HttpClient.PostAsync($"/api/v1/bucketlists/{bucket.Id}/activities/{activity.Id}", null);

            //Assert
            response.IsSuccessStatusCode.Should().BeTrue();
        }


        [Fact]
        public async Task GetBucketListByWrongId()
        {
            //Arrange

            //Act
            var response = await HttpClient.GetAsync($"/api/v1/bucketlists/{new Guid()}");

            //Assert
            response.IsSuccessStatusCode.Should().BeFalse();
        }

        [Fact]
        public async Task AddActivityInNotExistingBucketList()
        {
            //Arrange
            var activityType = ActivityTypeFactory.Default();
            var city = CityFactory.Default();
            var activity = ActivityFactory.Default(city.Id, activityType.Id);

            //Act
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Cities.AddAsync(city);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

             var response = await HttpClient.PostAsync($"/api/v1/bucketlists/{new Guid()}/activities/{activity.Id}", null);

            //Assert
            response.IsSuccessStatusCode.Should().BeFalse();
        }

        [Fact]
        public async Task AddNonExistingActivity()
        {
            //Arrange
            BucketList bucket = null;

            //Act
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                bucket = await doFestContext
                            .BucketLists
                            .FirstOrDefaultAsync(x => x.UserId == AuthenticatedUserId);
            });

            var response = await HttpClient.PostAsync($"/api/v1/bucketlists/{bucket.Id}/activities/{new Guid()}", null);

            //Assert
            response.IsSuccessStatusCode.Should().BeFalse();
        }

    }

}

