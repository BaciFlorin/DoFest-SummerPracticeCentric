

using System;
using System.Collections.Generic;

namespace DoFest.Business.Activities.Models.BucketList
{
    public class BucketListUpdateModel
    {
        public List<Guid> ActivitiesForDelete { get; set; }
        public List<Guid> ActivitiesForToggle { get; set; }

        public string Name { get; set; }
    }
}
