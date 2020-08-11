using DoFest.Entities.Activities;

namespace DoFest.IntegrationTests.Shared.Extensions
{
    public static class ActivityTypeExtension
    {
        public static ActivityType WithName(this ActivityType activityTypeEntity, string name)
        {
            return new ActivityType(
                name
                );
        }
    }
}
