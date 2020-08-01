using System;
using System.Collections.Generic;

namespace DoFest.Business.Activities.Models.BucketList
{
    public sealed class BucketListWithActivityIdModel
    {
        public Guid Id { get; private set; }

        public IList<Guid> ActivitiesId { get; private set; }

        public string Name { get; private set; }

        public string Username { get; private set; }

        public static BucketListWithActivityIdModel Create(Guid bucketListId,IList<Guid> activitiesId, string name, string username)
        {
            return new BucketListWithActivityIdModel
            {
                Id = bucketListId,
                ActivitiesId = activitiesId,
                Name = name,
                Username = username
            };
        }
    }
}
