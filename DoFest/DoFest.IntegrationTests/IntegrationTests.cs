using DoFest.API;
using DoFest.Business.Identity.Models;
using DoFest.Entities.Activities.Places;
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

        public Guid CityId { get; private set; }

        public IntegrationTests()
        {
            _webApplicationFactory = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder => { });
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
            doFestContext.UserTypes.RemoveRange(doFestContext.UserTypes);
            doFestContext.BucketLists.RemoveRange(doFestContext.BucketLists);
            doFestContext.Cities.RemoveRange(doFestContext.Cities);
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
            UserType userType = new UserType("Normal user", "access");
            City city = new City("Bucuresti");
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.UserTypes.AddAsync(userType);
                await doFestContext.Cities.AddAsync(city);
                await doFestContext.SaveChangesAsync();
                CityId = city.Id;
            });
            var userRegisterModel = new RegisterModel
            {
                Username = "testtest",
                Age = 20,
                BucketListName = "testtesttest",
                City = city.Id,
                Email = "testeesttest@gmail.com",
                Name = "testtesttest",
                Password = "passwordAdmin",
                Year = 3
            };
            
            var userRegisterResponse = await HttpClient.PostAsJsonAsync($"api/v1/auth/register", userRegisterModel);
            userRegisterResponse.IsSuccessStatusCode.Should().BeTrue();
            
            
            var authenticateModel = new LoginModelRequest
            {
                Email = userRegisterModel.Email,
                Password = userRegisterModel.Password
            };
            var userAuthenticateResponse = await HttpClient.PostAsJsonAsync($"api/v1/auth/login", authenticateModel);
            userAuthenticateResponse.IsSuccessStatusCode.Should().BeTrue();
            AuthenticatedUserId = new Guid();
            var authenticationResponseContent = await userAuthenticateResponse.Content.ReadAsAsync<LoginModelResponse>();

            AuthenticationToken = authenticationResponseContent.Token;
        }
    }
}