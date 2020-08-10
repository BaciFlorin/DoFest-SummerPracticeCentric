using DoFest.Business.Activities.Models.Activity;
using DoFest.Entities.Activities;
using DoFest.Entities.Activities.Places;
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
        [Fact]
        public async Task GetActivities()
        {
            var activityType = new ActivityType("gratar");
            var activity = new Activity(
                activityType.Id,
                CityId,
                "Nume activitate",
                "Adresa activitate",
                "Descriere activitate"
                );

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
            var activityType = new ActivityType("gratar");
            var activity = new Activity(
                activityType.Id,
                CityId,
                "Nume activitate",
                "Adresa activitate",
                "Descriere activitate"
                );

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
            var activityType = new ActivityType("gratar");
            City city = new City("Iasi");
            var activity = new CreateActivityModel()
            {
                ActivityTypeId = activityType.Id,
                Address = "test address",
                CityId = city.Id,
                Description = "test description",
                Name = "test name"
            };

            var response = await HttpClient.PostAsJsonAsync($"/api/v1/activities",activity);

            response.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task GetActivityByIdError()
        {
            var id = Guid.NewGuid();

            var response = await HttpClient.GetAsync($"/api/v1/activities/{id}");
            // var response = await HttpClient.GetStreamAsync($"/api/v1/activities/{activity.Id}");

            response.IsSuccessStatusCode.Should().BeFalse();
        }
    }
}
