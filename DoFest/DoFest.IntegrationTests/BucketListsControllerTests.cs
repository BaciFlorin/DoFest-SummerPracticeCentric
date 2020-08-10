using DoFest.Business.Activities.Models.BucketList;
using DoFest.Entities.Activities;
using DoFest.Entities.Lists;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DoFest.IntegrationTests
{
    public class BucketListsControllerTests : IntegrationTests
    {
        [Fact]
        public async Task GetAllBucketLists()
        {
            var activityType = new ActivityType("gratar");
            var activity = new Activity(
                activityType.Id,
                CityId,
                "Nume activitate",
                "Adresa activitate",
                "Descriere activitate"
                );

            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            var response = await HttpClient.GetAsync($"/api/v1/bucketlists");
            response.IsSuccessStatusCode.Should().BeTrue();

            var bkListName = await response.Content.ReadAsAsync<IList<BucketList>>();
            bkListName.Should().HaveCount(1);    
        }
    }

}

