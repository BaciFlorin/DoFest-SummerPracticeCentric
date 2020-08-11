using DoFest.Entities.Authentication.Notification;
using DoFest.Entities.Lists;
using DoFest.IntegrationTests.Shared.Extensions;
using DoFest.IntegrationTests.Shared.Factories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DoFest.IntegrationTests
{
    public class NotificationsControllerTests: IntegrationTests
    {
        [Fact]
        public async Task FindAllNotificationsUserTest()
        {
            // Arrange
            var activityType = ActivityTypeFactory.Default();
            var activity = ActivityFactory.Default(CityId, activityType.Id);
            var notification = NotificationFactory.Default(activity.Id);
            activity.AddNotification(notification);

            BucketList bucketList = null;
            BucketListActivity bucketListActivity = null;

            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.ActivityTypes.AddAsync(activityType);
                await doFestContext.SaveChangesAsync();
                bucketList = await doFestContext.BucketLists.FirstOrDefaultAsync(entity => entity.UserId == AuthenticatedUserId);
                if (bucketList != null)
                {
                    bucketListActivity = new BucketListActivity(bucketList.Id, activity.Id);
                    await doFestContext.BucketListActivities.AddAsync(bucketListActivity);
                    await doFestContext.Activities.AddAsync(activity);
                    await doFestContext.SaveChangesAsync();
                }
            });

            // Act
            var response = await HttpClient.GetAsync("api/v1/notifications");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var notifications = await response.Content.ReadAsAsync<IList<Notification>>();
            notifications.Should().HaveCount(1);
        }
    }
}
