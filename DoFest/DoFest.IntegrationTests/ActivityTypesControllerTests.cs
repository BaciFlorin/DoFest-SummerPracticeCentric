using DoFest.Business.Activities.Models.Activity.ActivityType;
using DoFest.Entities.Activities;
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
    public class ActivityTypesControllerTests: IntegrationTests
    {
        public ActivityTypesControllerTests() : base(true){}

        [Fact]
        public async Task GetActivityTypesTest()
        {
            var activityType = ActivityTypeFactory.Default();

            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.SaveChangesAsync();
            });

            var response = await HttpClient.GetAsync($"api/v1/activities/types");

            response.IsSuccessStatusCode.Should().BeTrue();
            var activityTypes = await response.Content.ReadAsAsync<IEnumerable<ActivityType>>();
            activityTypes.Should().HaveCount(1);

        }

        [Fact]
        public async Task PostActivityTypeTest()
        {
            var activityTypeModel = new CreateActivityTypeModel(){
                Name = "activitate test"
            };

            var response = await HttpClient.PostAsJsonAsync($"api/v1/activities/types", activityTypeModel);

            response.IsSuccessStatusCode.Should().BeTrue();
            var activityTypeId = new Guid(response.Headers.Location.OriginalString);
            ActivityType activityTypeEntity = null;
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                activityTypeEntity = await doFestContext
                    .ActivityTypes
                    .FirstOrDefaultAsync(entity => entity.Id == activityTypeId);
                await doFestContext.SaveChangesAsync();
            });
            activityTypeEntity.Should().NotBeNull();
        }

        [Fact]
        public async Task DeleteActivityTypeTest()
        {

            var activityType = ActivityTypeFactory.Default();

            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.SaveChangesAsync();
            });

            var response = await HttpClient.DeleteAsync($"api/v1/activities/types/{activityType.Id}");

            response.IsSuccessStatusCode.Should().BeTrue();

        }

        [Fact]
        public async Task PostInvalidActivityTypeTest()
        {
            var activityTypeModel = new CreateActivityTypeModel()
            {
                Name = "activitate test"
            };

            var response = await HttpClient.PostAsJsonAsync($"api/v1/activities/types", activityTypeModel);

            var secondResponse = await HttpClient.PostAsJsonAsync($"api/v1/activities/types", activityTypeModel);

            response.IsSuccessStatusCode.Should().BeTrue();
            secondResponse.IsSuccessStatusCode.Should().BeFalse();
        }

        [Fact]
        public async Task DeleteInvalidActivityTypeTest()
        {

            var response = await HttpClient.DeleteAsync($"api/v1/activities/types/{new Guid()}");

            response.IsSuccessStatusCode.Should().BeFalse();

        }
    }
}
