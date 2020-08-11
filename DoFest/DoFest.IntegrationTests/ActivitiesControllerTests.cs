using DoFest.Business.Activities.Models.Activity;
using DoFest.Entities.Activities;
using DoFest.IntegrationTests.Shared.Extensions;
using DoFest.IntegrationTests.Shared.Factories;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DoFest.IntegrationTests
{
    public class ActivitiesControllerTests : IntegrationTests
    {
        public ActivitiesControllerTests() : base(true)
        {

        }

        [Fact]
        public async Task GetActivities()
        {
            //Arrange
            var activityType = ActivityTypeFactory.Default();
            var activity = ActivityFactory.Default(CityId, activityType.Id);

            //Act
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            var response = await HttpClient.GetAsync($"/api/v1/activities");
            
            //Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var activities = await response.Content.ReadAsAsync<IList<Activity>>();
            activities.Should().HaveCount(1);
        }

        [Fact]
        public async Task GetActivityById()
        {
            //Arrange
            var activityType = ActivityTypeFactory.Default();
            var activity = ActivityFactory.Default(CityId, activityType.Id);

            //Act
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            var response = await HttpClient.GetAsync($"/api/v1/activities/{activity.Id}");
            
            //Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var activities = await response.Content.ReadAsAsync<Activity>();

            activities.Id.Should().Equals(activity.Id);
        }

        [Fact]
        public async Task AddNewActivity()
        {
            //Arrange
            var activityType = ActivityTypeFactory.Default();
            var city = CityFactory.Default();

            var activity = new CreateActivityModel()
            {
                ActivityTypeId = activityType.Id,
                Address = "test address",
                CityId = city.Id,
                Description = "test description",
                Name = "test name"
            };

            //Act
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Cities.AddAsync(city);
                await doFestContext.SaveChangesAsync();
            });

            //Assert
            var response = await HttpClient.PostAsJsonAsync($"/api/v1/activities", activity);

            response.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task GetActivityByIdError()
        {
            //Arrange
            var activity = Guid.NewGuid();

            //Act
            var response = await HttpClient.GetAsync($"/api/v1/activities/{activity}");

            //Assert
            response.IsSuccessStatusCode.Should().BeFalse();
        }

        [Fact]
        public async Task DeleteActivity()
        {
            //Arrange
            var activityType = ActivityTypeFactory.Default();
            var city = CityFactory.Default();
            var activity = new Activity(activityType.Id, city.Id, "test name", "test description", "test address");

            //Act
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Cities.AddAsync(city);
                await doFestContext.SaveChangesAsync();
            });
           
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            var response = await HttpClient.DeleteAsync($"/api/v1/activities/{activity.Id}");
            
            //Assert
            response.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task AddNullCityActivity()
        {
            //Arrange
            var activityType = ActivityTypeFactory.Default();
            var city = CityFactory.Default();
            var activity = new CreateActivityModel()
            {
                ActivityTypeId = activityType.Id,
                Address = "test address",
                CityId = city.Id,
                Description = "test description",
                Name = null
            };


            //Act
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.SaveChangesAsync();
            });

            var response = await HttpClient.PostAsJsonAsync($"/api/v1/activities", activity);

            //Assert
            response.IsSuccessStatusCode.Should().BeFalse();
        }

        [Fact]
        public async Task DeleteActivityInvalidID()
        {
            //Arrange

            //Act

            var response = await HttpClient.DeleteAsync($"/api/v1/activities/{new Guid()}");

            //Assert
            response.IsSuccessStatusCode.Should().BeFalse();
        }
    }
}
