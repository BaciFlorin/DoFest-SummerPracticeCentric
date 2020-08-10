using DoFest.Entities.Activities.Places;
using System;

namespace DoFest.Business.Activities.Models.Activity
{
    public sealed class ActivityModel
    {
        public ActivityModel(Guid id, Guid activityTypeId, string name, Guid cityId, string address, string description, int trending)
        {
            Id = id;
            ActivityTypeId = activityTypeId;
            Name = name;
            CityId = cityId;
            Address = address;
            Description = description;
            Trending = trending;
        }

        private ActivityModel()
        {

        }

        public Guid ActivityTypeId { get; private set; }

        public string Name { get; private set; }

        public Guid Id { get; private set; }

        public Guid CityId { get; private set; }

        public string Address { get; private set; }

        public string Description { get; private set; }

        public int Trending { get; private set; }

    }
}
