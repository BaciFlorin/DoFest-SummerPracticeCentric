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
            var response = await HttpClient.GetAsync($"api/v1/activities");

            response.IsSuccessStatusCode.Should().BeTrue();
        }
    }
}
