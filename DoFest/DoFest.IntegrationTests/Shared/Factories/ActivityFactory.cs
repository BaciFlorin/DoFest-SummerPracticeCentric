using DoFest.Entities.Activities;
using System;

namespace DoFest.IntegrationTests.Shared.Extensions
{
    public static class ActivityFactory
    {
        public static Activity Default(Guid cityId, Guid activityTypeId)
        {
            return new Activity(
                activityTypeId,
                cityId,
                "Nume activitate",
                "Adresa activitate",
                "Descriere activitate"
                );
        }

        internal static object Default(object cityId, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
