using DoFest.Entities.Lists;
using DoFest.IntegrationTests.Shared.Extensions;
using DoFest.IntegrationTests.Shared.Factories;
using DoFest.Persistence;
using FluentAssertions;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DoFest.IntegrationTests
{
    public class BucketListsControllerTests : IntegrationTests
    {
        [Fact]
        public async Task GetAllBucketLists()
        {
            var response = await HttpClient.GetAsync($"/api/v1/bucketlists");
            response.IsSuccessStatusCode.Should().BeTrue();

            var bkListName = await response.Content.ReadAsAsync<IList<BucketList>>();
            bkListName.Should().HaveCount(1);
        }

        [Fact]
        public async Task GetBucketListById()
        {
            var existingBkListId = new Guid();

            await ExecuteDatabaseAction(async (DoFestContext) =>
            {
                var existingBkList = await DoFestContext
                                        .BucketLists
                                        .Include(entity => entity.BucketListActivities)
                                        .FirstAsync(entity => entity.UserId == AuthenticatedUserId);

                existingBkListId = existingBkList.Id;
            });

            var response = await HttpClient.GetAsync($"/api/v1/bucketlists/{existingBkListId}");

            response.IsSuccessStatusCode.Should().BeTrue();

            var bkList = await response.Content.ReadAsAsync<BucketList>();

            bkList.UserId.Should().Equals(AuthenticatedUserId);
        }

        [Fact]
        public async Task AddActivityInBucketList()
        {
            var activityType = ActivityTypeFactory.Default();
            var city = CityFactory.Default();
            var activity = ActivityFactory.Default(city.Id, activityType.Id);
            BucketList bucket = null;

            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Cities.AddAsync(city);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();

                bucket = await doFestContext
                            .BucketLists
                            .FirstOrDefaultAsync(x => x.UserId == AuthenticatedUserId);

            });

            var response = await HttpClient.PostAsync($"/api/v1/bucketlists/{bucket.Id}/activities/{activity.Id}",null);

            response.IsSuccessStatusCode.Should().BeTrue();
        }
    }
}

