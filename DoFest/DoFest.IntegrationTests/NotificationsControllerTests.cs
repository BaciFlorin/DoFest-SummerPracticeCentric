using DoFest.IntegrationTests.Shared.Extensions;
using DoFest.IntegrationTests.Shared.Factories;
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

            await ExecuteDatabaseAction(async (doFestContext) =>
            {
                await doFestContext.Activities.AddAsync(activity);
                await doFestContext.SaveChangesAsync();
            });

            // Act
            var response =  HttpClient.GetAsync("api/v1/notifications");

            // Assert
        }
    }
}
