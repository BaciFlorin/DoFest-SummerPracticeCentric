using DoFest.Business.Activities.Models.BucketList;
using System;
using System.Collections.Generic;

namespace DoFest.UnitTests.Shared.Factories
{
    public class BucketListUpdateModelFactory
    {
        public static BucketListUpdateModel Default()
        {
            return new BucketListUpdateModel()
            {
                ActivitiesForToggle = new List<Guid>(){ Guid.NewGuid(), Guid.NewGuid()},
                ActivitiesForDelete = new List<Guid>(){ Guid.NewGuid(), Guid.NewGuid()},
                Name = "BucketList"
            };
        }
    }
}
