using DoFest.API;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DoFest.IntegrationTests
{
    public class IntegrationTests : IAsyncLifetime
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;

        protected HttpClient HttpClient { get; private set; }

        protected string AuthenticationToken { get; private set; }

        protected Guid AuthenticatedUserId { get; private set; }

        // Adaugarea Loggerului
        // protected Mock<IDomainLogger> MockLogger { get; private set; }

        public Task DisposeAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task InitializeAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
