using DoFest.Business.Activities.Models.Activity;
using System;

namespace DoFest.UnitTests.Shared.Extensions
{
    public static class CreateActivityModelExtensions
    {
        public static CreateActivityModel WithActivityType(this CreateActivityModel model, Guid activityTypeId)
        {
            model.ActivityTypeId = activityTypeId;
            return model;
        }

        public static CreateActivityModel WithAddress(this CreateActivityModel model, string address)
        {
            model.Address = address;
            return model;
        }

        public static CreateActivityModel WithCityId(this CreateActivityModel model, Guid cityId)
        {
            model.CityId = cityId;
            return model;
        }

        public static CreateActivityModel WithDescription(this CreateActivityModel model, string description)
        {
            model.Description = description;
            return model;
        }

        public static CreateActivityModel WithName(this CreateActivityModel model, string name)
        {
            model.Name = name;
            return model;
        }
    }
}
