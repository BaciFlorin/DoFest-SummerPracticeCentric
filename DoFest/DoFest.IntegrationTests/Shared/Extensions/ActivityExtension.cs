using DoFest.Entities.Activities;
using System;

namespace DoFest.IntegrationTests.Shared.Extensions
{
    public static class ActivityExtension
    {
        public static Activity WithCityId(this Activity activityEntity, Guid cityId )
        {
            return new Activity(
                activityEntity.ActivityTypeId,
                cityId,
                activityEntity.Name,
                activityEntity.Address,
                activityEntity.Description
                );
        }

        public static Activity WithActivityTypeId(this Activity activityEntity, Guid activityTypeId)
        {
            return new Activity(
                activityTypeId,
                activityEntity.CityId,
                activityEntity.Name,
                activityEntity.Address,
                activityEntity.Description
                );
        }

        public static Activity WithName(this Activity activityEntity, string name)
        {
            return new Activity(
                activityEntity.ActivityTypeId,
                activityEntity.CityId,
                name,
                activityEntity.Address,
                activityEntity.Description
                );
        }

        public static Activity WithAddress(this Activity activityEntity, string address)
        {
            return new Activity(
                activityEntity.ActivityTypeId,
                activityEntity.CityId,
                activityEntity.Name,
                address,
                activityEntity.Description
                );
        }

        public static Activity WithDescritprion(this Activity activityEntity, string description)
        {
            return new Activity(
                activityEntity.ActivityTypeId,
                activityEntity.CityId,
                activityEntity.Name,
                activityEntity.Address,
                description
                );
        }
    }
}
