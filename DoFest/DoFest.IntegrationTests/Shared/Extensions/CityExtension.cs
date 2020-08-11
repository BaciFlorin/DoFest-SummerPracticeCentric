using DoFest.Entities.Activities.Places;

namespace DoFest.IntegrationTests.Shared.Extensions
{
    public static class CityExtension
    {
        public static City WithName(this City cityEntity, string name)
        {
            return new City(
                name
                );
        }
    }
}
