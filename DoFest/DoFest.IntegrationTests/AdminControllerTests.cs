using DoFest.Entities.Authentication;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DoFest.IntegrationTests
{
    public class AdminControllerTests : IntegrationTests
    {
        public AdminControllerTests() : base(true)
        {

        }

        [Fact]
        public async Task GetUsers()
        {
            //Arrange

            // Act

            var response = await HttpClient.GetAsync($"/api/v1/admin/users");

            // Assert       
            response.IsSuccessStatusCode.Should().BeTrue();

            var users = await response.Content.ReadAsAsync<IList<User>>();

            users.Should().HaveCount(1);
        }

        [Fact]
        public async Task GetUserTypes()
        {
            //Arrange

            // Act

            var response = await HttpClient.GetAsync($"/api/v1/admin/userTypes");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();

            var users = await response.Content.ReadAsAsync<IList<User>>();

            users.Should().HaveCount(2);
        }

        [Fact]
        public async Task ToggleUserTypeStatus()
        {
            //Arrange

            UserType NormalUserType = null;

            User user = null;
            // Act

            var response = await HttpClient.PatchAsync($"/api/v1/admin/user/{AuthenticatedUserId}/usertype/toggle", null);

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();

            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                NormalUserType = await doFestContext
                                        .UserTypes
                                        .FirstAsync(entity => entity.Name == "Normal user");
            });

            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                user = await doFestContext
                                        .Users
                                        .FirstAsync(entity => entity.UserTypeId == NormalUserType.Id);
            });

            user.Should().Equals(NormalUserType);


        }
    }
}
