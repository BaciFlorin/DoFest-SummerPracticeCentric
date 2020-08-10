using DoFest.Business.Activities.Models.Places;
using DoFest.Entities.Activities.Places;
using DoFest.IntegrationTests.Shared.Extensions;
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
    public class CitiesControllerTests: IntegrationTests
    {
        public CitiesControllerTests() : base(true)
        {

        }
        [Fact]
        public async Task GetCitiesTest()
        {
            //Arrange

            // Act
            var response = await HttpClient.GetAsync("/api/v1/cities");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var cities = await response.Content.ReadAsAsync<IList<City>>();
            cities.Should().HaveCount(1);
        }

        [Fact]
        public async Task CreateCityTest()
        {
            //Arrange
            var cityModel = new CreateCityModel()
            {
                Name = "Buzau"
            };

            // Act
            var response = await HttpClient.PostAsJsonAsync("/api/v1/cities", cityModel);

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            City city = null;
            await ExecuteDatabaseAction(async (doFestContext) => {
                city = await doFestContext.Cities.FirstAsync(entity => entity.Name == cityModel.Name);
            });
            city.Name.Should().NotBeNull();
        }

        [Fact]
        public async Task DeleteCityTest()
        {
            //Arrange
            var city = CityFactory.Default().WithName("Bacau");
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.Cities.AddAsync(city);
                await doFestContext.SaveChangesAsync();
            });

            // Act
            var response = await HttpClient.DeleteAsync($"/api/v1/cities/{city.Id}");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            City existingCity = null;
            await ExecuteDatabaseAction(async (doFestContext) => {
                existingCity = await doFestContext.Cities.FirstOrDefaultAsync(entity => entity.Name == city.Name);
            });
            existingCity.Should().BeNull();
        }

        [Fact]
        public async Task DeleteInvalidCityTest()
        {
            //Arrange
            var cityId = Guid.NewGuid();

            // Act
            var response = await HttpClient.DeleteAsync($"/api/v1/cities/{cityId}");

            // Assert
            response.IsSuccessStatusCode.Should().BeFalse();
        }

        [Fact]
        public async Task CreateInvalidCityTest()
        {
            //Arrange
            var cityModel = new CreateCityModel()
            {
                Name = "Buzau"
            };

            // Act
            var firstResponse = await HttpClient.PostAsJsonAsync("/api/v1/cities", cityModel);

            var secondResponse = await HttpClient.PostAsJsonAsync("/api/v1/cities", cityModel);

            // Assert
            firstResponse.IsSuccessStatusCode.Should().BeTrue();
            secondResponse.IsSuccessStatusCode.Should().BeFalse();
        }
    }
}
