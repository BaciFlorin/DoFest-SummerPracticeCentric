using DoFest.Entities.Activities.Places;

namespace DoFest.IntegrationTests.Shared.Factories
{
    public static class CityFactory
    {
        public static City Default()
        {
            return new City("Bucuresti");
        }
    }
}
