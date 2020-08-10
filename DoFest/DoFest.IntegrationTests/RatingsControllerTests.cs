using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DoFest.Business.Activities.Models.Content.Ratings;
using DoFest.Entities.Activities.Content;
using DoFest.IntegrationTests.Shared.Extensions;
using DoFest.IntegrationTests.Shared.Factories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DoFest.IntegrationTests
{
    public class RatingsControllerTests: IntegrationTests
    {
        [Fact]
        public async Task GetActivityRatings()
        {
            //Arrange
            var activityType = ActivityTypeFactory.Default();
            var activity = ActivityFactory.Default(CityId, activityType.Id);

            var rating= new Rating(activityType.Id, this.AuthenticatedUserId, 5);

            activity.AddRating(rating);

            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            //Act
            var response = await HttpClient.GetAsync($"api/v1/activities/{activity.Id}/ratings");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var ratings = await response.Content.ReadAsAsync<IList<RatingModel>>();
            ratings.Should().HaveCount(1);

        }

        [Fact]
        public async Task AddRatingToActivity()
        {
            var activityType = ActivityTypeFactory.Default();
            var activity = ActivityFactory.Default(CityId, activityType.Id);

            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            var createRatingModel = new CreateRatingModel
            {
                Stars = 5
            };

            //Act
            var response = await HttpClient.PostAsJsonAsync($"api/v1/activities/{activity.Id}/ratings",
                createRatingModel);

            //Assert
            response.IsSuccessStatusCode.Should().BeTrue();

            var createdRatingId = response.Headers.Location.OriginalString;
            Rating existingRating = null;
            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                var existingActivity = await doFestContext.Activities
                    .Include(entity => entity.Ratings)
                    .FirstAsync(entity => entity.Id == activity.Id);

                existingRating = existingActivity.Ratings.FirstOrDefault();
            });

            existingRating.Should().NotBeNull();
            existingRating.Id.Should().Be(createdRatingId);
        }

        [Fact]
        public async Task GetInvalidActivityRatings()
        {
            //Arrange
           

            //Act
            var response = await HttpClient.GetAsync($"api/v1/activities/{new Guid()}/ratings");

            // Assert
            response.IsSuccessStatusCode.Should().BeFalse();

        }


        [Fact]
        public async Task AddRatingToInvalidActivity()
        {

            var createRatingModel = new CreateRatingModel
            {
                Stars = 5
            };

            //Act
            var response = await HttpClient.PostAsJsonAsync($"api/v1/activities/{new Guid()}/ratings",
                createRatingModel);

            //Assert
            response.IsSuccessStatusCode.Should().BeFalse();
        }
    }
}
