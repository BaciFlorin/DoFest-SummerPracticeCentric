using DoFest.Business.Activities.Models.Activity;
using System;

namespace DoFest.UnitTests.Shared.Factories
{
    public static class CreateActivityModelFactory
    {
        public static CreateActivityModel Default()
        {
            return new CreateActivityModel()
            {
                ActivityTypeId = Guid.NewGuid(),
                Address = "adresa",
                CityId = Guid.NewGuid(),
                Description = "descriere",
                Name = "nume"
            };
        }
    }
}
