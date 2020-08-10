using DoFest.Business.Activities.Models.Activity;
using DoFest.Entities.Activities;
using DoFest.IntegrationTests.Shared.Extensions;
using DoFest.IntegrationTests.Shared.Factories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
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
            var activityType = ActivityTypeFactory.Default();
            var activity = ActivityFactory.Default(CityId, activityType.Id);

            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            var response = await HttpClient.GetAsync($"/api/v1/activities");

            response.IsSuccessStatusCode.Should().BeTrue();
            var activities = await response.Content.ReadAsAsync<IList<Activity>>();
            activities.Should().HaveCount(1);
        }

        [Fact]
        public async Task GetActivityById()
        {
            var activityType = ActivityTypeFactory.Default();
            var activity = ActivityFactory.Default(CityId, activityType.Id);

            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            var response = await HttpClient.GetAsync($"/api/v1/activities/{activity.Id}");
            // var response = await HttpClient.GetStreamAsync($"/api/v1/activities/{activity.Id}");

            response.IsSuccessStatusCode.Should().BeTrue();
            var activities = await response.Content.ReadAsAsync<Activity>();

            activities.Id.Should().Equals(activity.Id);
        }

        [Fact]
        public async Task AddNewActivity()
        {
            var activityType = ActivityTypeFactory.Default();
            var city = CityFactory.Default();
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Cities.AddAsync(city);
                await doFestContext.SaveChangesAsync();
            });
            var activity = new CreateActivityModel()
            {
                ActivityTypeId = activityType.Id,
                Address = "test address",
                CityId = city.Id,
                Description = "test description",
                Name = "test name"
            };


            var response = await HttpClient.PostAsJsonAsync($"/api/v1/activities", activity);

            response.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task GetActivityByIdError()
        {
            var activity = Guid.NewGuid();

            var response = await HttpClient.GetAsync($"/api/v1/activities/{activity}");
            // var response = await HttpClient.GetStreamAsync($"/api/v1/activities/{activity.Id}");

            response.IsSuccessStatusCode.Should().BeFalse();
        }

        [Fact]
        public async Task DeleteActivity()
        {
            var activityType = ActivityTypeFactory.Default();
            var city = CityFactory.Default();
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Cities.AddAsync(city);
                await doFestContext.SaveChangesAsync();
            });
            var activity = new Activity(activityType.Id, city.Id, "test name",  "test description", "test address");
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            var response = await HttpClient.DeleteAsync($"/api/v1/activities/{activity.Id}");

            response.IsSuccessStatusCode.Should().BeTrue();
        }
    }
}
