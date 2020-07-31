using System;

namespace DoFest.Business.Models.Activity
{
    public sealed class CreateActivityModel
    {
        public Guid? ActivityTypeId { get; set; }

        public string Name { get; set; }

        public Guid? LocationId { get; set; }

        public string Description { get; set; }
    }
}
