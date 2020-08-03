using System;

namespace DoFest.Business.Activities.Models.Activity
{
    public sealed class CreateActivityModel
    {
        public Guid ActivityTypeId { get; set; }

        public string Name { get; set; }

        public Guid CityId { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }
    }
}
