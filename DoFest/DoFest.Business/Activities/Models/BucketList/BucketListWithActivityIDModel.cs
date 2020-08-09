using System;
using System.Collections.Generic;
using DoFest.Business.Activities.Models.Activity;

namespace DoFest.Business.Activities.Models.BucketList
{
    public sealed class BucketListWithActivityIdModel
    {

        public IList<ActivityWithStatusModel> Activities { get; private set; }

        public string Name { get; private set; }

        public string Username { get; private set; }

        public static BucketListWithActivityIdModel Create(IList<ActivityWithStatusModel> activities, string name, string username)
        {
            return new BucketListWithActivityIdModel
            {
                Activities = activities,
                Name = name,
                Username = username
            };
        }
    }
}
