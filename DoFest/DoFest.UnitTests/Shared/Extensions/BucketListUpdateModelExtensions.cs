using DoFest.Business.Activities.Models.BucketList;
using System;
using System.Collections.Generic;

namespace DoFest.UnitTests.Shared.Extensions
{
    public static class BucketListUpdateModelExtensions
    {
        public static BucketListUpdateModel WithActivitiesForDelete(this BucketListUpdateModel model, List<Guid> activities)
        {
            model.ActivitiesForDelete = activities;
            return model;
        }

        public static BucketListUpdateModel WithActivitiesForToggle(this BucketListUpdateModel model, List<Guid> activities)
        {
            model.ActivitiesForToggle = activities;
            return model;
        }

        public static BucketListUpdateModel WithName(this BucketListUpdateModel model, string name)
        {
            model.Name = name;
            return model;
        }
    }
}
