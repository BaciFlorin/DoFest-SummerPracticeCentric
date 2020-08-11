using System.Net.Http;
using System.Threading.Tasks;
using DoFest.Business.Identity.Models;
using FluentAssertions;
using Xunit;

namespace DoFest.IntegrationTests
{
    public class AuthenticationControllerTests:IntegrationTests
    {

        [Fact]
        public async Task InvalidEmailLogin()
        {

            LoginModelRequest loginModel = new LoginModelRequest
            {
                Email = "testeesttest1@gmail.com",
                Password = "parola99"
            };

            var userAuthenticateResponse = await HttpClient.PostAsJsonAsync($"api/v1/auth/login", loginModel);
            userAuthenticateResponse.IsSuccessStatusCode.Should().BeFalse();
        }


        [Fact]
        public async Task InvalidPasswordLogin()
        {

            LoginModelRequest loginModel = new LoginModelRequest
            {
                Email = "testeesttest@gmail.com",
                Password = "parola9999"
            };

            var userAuthenticateResponse = await HttpClient.PostAsJsonAsync($"api/v1/auth/login", loginModel);
            userAuthenticateResponse.IsSuccessStatusCode.Should().BeFalse();
        }


        [Fact]
        public async Task ExistingEmailRegister()
        {

            RegisterModel registerModel = new RegisterModel
            {
                Username = "testtest",
                Age = 20,
                BucketListName = "test bucketlist",
                City = CityId,
                Email = "testeesttest@gmail.com",
                Name = "testtest",
                Password = "passwordAdmin",
                Year = 3
            };

            var userAuthenticateResponse = await HttpClient.PostAsJsonAsync($"api/v1/auth/register", registerModel);
            userAuthenticateResponse.IsSuccessStatusCode.Should().BeFalse();
        }

        [Fact]
        public async Task ChangePassword()
        {
            NewPasswordModelRequest newPasswordModel = new NewPasswordModelRequest
            {
                NewPassword = "parolaNoua"
            };

            var response = await HttpClient.PutAsJsonAsync($"api/v1/auth/change-password", newPasswordModel);

            response.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task ChangeInvalidPassword()
        {
            NewPasswordModelRequest newPasswordModel = new NewPasswordModelRequest
            {
                NewPassword = "parolaNoua"
            };

            var firstResponse = await HttpClient.PutAsJsonAsync($"api/v1/auth/change-password", newPasswordModel);

            var secondResponse = await HttpClient.PutAsJsonAsync($"api/v1/auth/change-password", newPasswordModel);

            firstResponse.IsSuccessStatusCode.Should().BeTrue();
            secondResponse.IsSuccessStatusCode.Should().BeFalse();
        }

    }
}
