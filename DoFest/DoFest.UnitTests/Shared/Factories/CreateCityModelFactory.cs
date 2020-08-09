using DoFest.Business.Activities.Models.Places;

namespace DoFest.UnitTests.Shared.Factories
{
    public static class CreateCityModelFactory
    {
        public static CreateCityModel Default()
        {
            return new CreateCityModel()
            {
                Name = "nume oras"
            };
        }
    }
}
