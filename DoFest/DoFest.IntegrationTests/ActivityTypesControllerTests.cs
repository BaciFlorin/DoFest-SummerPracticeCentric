using AutoMapper.Mappers;
using DoFest.Business.Activities.Models.Activity;
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
        [Fact]
        public async Task GetActivityTypesTest()
        {
            var activityType = ActivityTypeFactory.Default();

            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.SaveChangesAsync();
            });

            var response = await HttpClient.GetAsync($"/api/v1/activities");

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

            var response = await HttpClient.PostAsJsonAsync($"/api/v1/activities", activityTypeModel);

            response.IsSuccessStatusCode.Should().BeTrue();
            var activityTypeId = await response.Content.ReadAsAsync<string>();
            var activityTypeIdGuid = new Guid(activityTypeId);
            ActivityType activityTypeEntity = null;
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                activityTypeEntity = await doFestContext
                    .ActivityTypes
                    .FirstOrDefaultAsync(entity => entity.Id == activityTypeIdGuid);
                await doFestContext.SaveChangesAsync();
            });
            activityTypeEntity.Should().NotBeNull();
        }

        [Fact]
        public async Task DeleteActivityTypeTest()
        {

        }
    }
}
