using DoFest.Business.Activities.Models.Activity;
using DoFest.Entities.Activities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DoFest.IntegrationTests
{
    public class ActivitiesControllerTests : IntegrationTests
    {
         [Fact]
         public async Task GetAllActivities()
        {
            // Arange


            // Act
            var result = await HttpClient.GetAsync($"/api/v1/activities");

            // Assert
            result.IsSuccessStatusCode.Should().BeTrue();


            //var act = new CreateActivityModel();// {new Guid("04e2145a-d872-11ea-87d0-0242ac130003"),};

            //act.ActivityTypeId = new Guid("04e2145a-d872-11ea-87d0-0242ac130003");
            ////declar toate campurile

            ////add to context await execute database

            //var response = await HttpClient.GetAsync($"api/v1/activities");

            //response.IsSuccessStatusCode.Should().BeTrue();
        }
    }
}
