using DoFest.Business.Activities.Models.Places;

namespace DoFest.UnitTests.Shared.Extensions
{
    public static class CreateCityModelExtensions
    {
        public static CreateCityModel WithName(this CreateCityModel model, string name)
        {
            model.Name = name;
            return model;
        }
    }
}
