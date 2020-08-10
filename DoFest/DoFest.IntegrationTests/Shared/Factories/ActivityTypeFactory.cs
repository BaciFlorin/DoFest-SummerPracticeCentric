using DoFest.Entities.Activities;

namespace DoFest.IntegrationTests.Shared.Factories
{
    public static class ActivityTypeFactory
    {
        public static ActivityType Default()
        {
            return new ActivityType(
                "activitate"
                );
        }
    }
}
