using DoFest.API;
using DoFest.Business.Identity.Models;
using DoFest.Entities.Authentication;
using DoFest.Persistence;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace DoFest.IntegrationTests
{

    public class IntegrationTests : IAsyncLifetime
    {
        private readonly WebApplicationFactory<Startup> _webApplicationFactory;
        protected HttpClient HttpClient { get; private set; }
        protected string AuthenticationToken { get; private set; }
        public Guid AuthenticatedUserId { get; private set; }

        public IntegrationTests()
        {
            _webApplicationFactory = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>{});
            HttpClient = _webApplicationFactory.CreateClient();

        }

        protected async Task ExecuteDatabaseAction(Func<DoFestContext, Task> databaseAction)
        {
            using (var scope = _webApplicationFactory.Services.CreateScope())
            {
                var doFestContext = scope.ServiceProvider.GetRequiredService<DoFestContext>();

                await databaseAction(doFestContext);
            }
        }

        public async Task CleanUpDataBase(DoFestContext doFestContext)
        {
            doFestContext.Users.RemoveRange(doFestContext.Users);
           // doFestContext.UserTypes.RemoveRange(doFestContext.UserTypes);
            doFestContext.BucketLists.RemoveRange(doFestContext.BucketLists);
            //doFestContext.Cities.RemoveRange(doFestContext.Cities);
            doFestContext.Activities.RemoveRange(doFestContext.Activities);
            doFestContext.ActivityTypes.RemoveRange(doFestContext.ActivityTypes);
            doFestContext.BucketListActivities.RemoveRange(doFestContext.BucketListActivities);

            await doFestContext.SaveChangesAsync();
      }

        public async Task InitializeAsync()
        {
            try
            {
                await ExecuteDatabaseAction(async (doFestContext) => await CleanUpDataBase(doFestContext));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            await SetAuthenticationToken();
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthenticationToken);
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
        private async Task SetAuthenticationToken()
        {
            var userRegisterModel = new RegisterModel
            {
                Username = "test",
                Age = 10,
                BucketListName = "testBKlist",
                City = new Guid("e4e03caf-b93a-4d38-9305-04f71483a2ab"),
                Email = "test@gmail.com",
                Name = "testName",
                Password = "testPass",
                UserType = new Guid("0a7540b5-4ce8-4881-9849-e87065cc521e"),
                Year = 3
            };
            var userRegisterResponse = await HttpClient.PostAsJsonAsync($"api/v1/auth/register", userRegisterModel);
            userRegisterResponse.IsSuccessStatusCode.Should().BeTrue();
            AuthenticatedUserId = new Guid(userRegisterResponse.Headers.Location.OriginalString);
            var user = new User("test@gmail.com", "testPass");
            var authenticateModel = new LoginModelRequest
            { 
                Email = userRegisterModel.Email,
                Password = userRegisterModel.Password
            };
            var userAuthenticateResponse = await HttpClient.PostAsJsonAsync($"api/v1/auth/login", authenticateModel);
            userAuthenticateResponse.IsSuccessStatusCode.Should().BeTrue();
            var authenticationResponseContent = await userAuthenticateResponse.Content.ReadAsAsync<LoginModelResponse>();

            AuthenticationToken = authenticationResponseContent.Token;
        }
    }
}
