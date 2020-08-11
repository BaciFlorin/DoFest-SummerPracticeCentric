using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace DoFest.IntegrationTests
{
    public class NotAdminControllerTest : IntegrationTests
    {
        [Fact]
        public async Task GetUsers()
        {
            //Arrange

            //Act
            var response = await HttpClient.GetAsync($"/api/v1/admin/users");

            //Assert
            response.IsSuccessStatusCode.Should().BeFalse();

        }


        [Fact]
        public async Task GetUserTypes()
        {
            //Arrange

            //Act
            var response = await HttpClient.GetAsync($"/api/v1/admin/userTypes");

            //Assert
            response.IsSuccessStatusCode.Should().BeFalse();
        }

        [Fact]
        public async Task ToggleUserTypeStatus()
        {
            //Arrange

            // Act
            var response = await HttpClient.PatchAsync($"/api/v1/admin/user/{AuthenticatedUserId}/usertype/toggle", null);

            // Assert
            response.IsSuccessStatusCode.Should().BeFalse();
        }
    }
}
