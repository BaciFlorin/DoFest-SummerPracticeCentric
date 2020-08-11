using System;

namespace DoFest.Business.Activities.Models.Places
{
    public sealed class CityModel
    {
        private CityModel()
        {

        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }
    }
}