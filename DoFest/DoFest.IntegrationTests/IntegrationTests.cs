using DoFest.API;
using DoFest.Business.Identity.Models;
using DoFest.Entities.Activities.Places;
using DoFest.Entities.Authentication;
using DoFest.IntegrationTests.Repositories;
using DoFest.IntegrationTests.Shared.Extensions;
using DoFest.IntegrationTests.Shared.Factories;
using DoFest.Persistence;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

        private bool _isAdmin;

        private IntegrationsTestsDbContext dbContext;

        private IntegrationTestsDbConextUserType userTypeDbContext;

        public IntegrationTests(bool isAdmin = false)
        {
            _webApplicationFactory = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder => { });
            HttpClient = _webApplicationFactory.CreateClient();
            _isAdmin = isAdmin;
            var optionsBuilder = new DbContextOptionsBuilder<IntegrationsTestsDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=DoFest;Trusted_Connection=True;");
            dbContext = new IntegrationsTestsDbContext(optionsBuilder.Options);

            var optionBuilder2 = new DbContextOptionsBuilder<IntegrationTestsDbConextUserType>();
            optionBuilder2.UseSqlServer("Server=localhost;Database=DoFest;Trusted_Connection=True;");
            userTypeDbContext = new IntegrationTestsDbConextUserType(optionBuilder2.Options);
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
            UserType userType = UserTypeFactory.Default();
            UserType admin = UserTypeFactory.Default().WithName("Admin");

            City city = CityFactory.Default();
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.UserTypes.AddAsync(userType);
                await doFestContext.UserTypes.AddAsync(admin);
                await doFestContext.Cities.AddAsync(city);
                await doFestContext.SaveChangesAsync();
                CityId = city.Id;
            });

            var userRegisterModel = new RegisterModel
            {
                Username = "testtest",
                Age = 20,
                BucketListName = "test bucketlist",
                City = city.Id,
                Email = "testeesttest@gmail.com",
                Name = "testtest",
                Password = "passwordAdmin",
                Year = 3
            };

            var userRegisterResponse = await HttpClient.PostAsJsonAsync($"api/v1/auth/register", userRegisterModel);
            userRegisterResponse.IsSuccessStatusCode.Should().BeTrue();
            if (_isAdmin == true)
            {
                var userRespository = new UserRepository(dbContext);
                var userTypeRepository = new UserTypeRepository(userTypeDbContext);
                var userTypeAdmin = await userTypeRepository.GetByName("Admin");
                var user = await userRespository.GetByEmail(userRegisterModel.Email);
                user.UserTypeId = userTypeAdmin.Id;
                userRespository.Update(user);
                await userRespository.SaveChanges();
            }
            var authenticateModel = new LoginModelRequest
            {
                Email = userRegisterModel.Email,
                Password = userRegisterModel.Password
            };
            var userAuthenticateResponse = await HttpClient.PostAsJsonAsync($"api/v1/auth/login", authenticateModel);
            userAuthenticateResponse.IsSuccessStatusCode.Should().BeTrue();
            AuthenticatedUserId = new Guid();
            var authenticationResponseContent = await userAuthenticateResponse.Content.ReadAsAsync<LoginModelResponse>();

            var stream = authenticationResponseContent.Token;
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(stream) as JwtSecurityToken;

            AuthenticatedUserId = new Guid(tokenS.Claims.First(x => x.Type == "userId").Value);

            AuthenticationToken = authenticationResponseContent.Token;
        }
    }
}