using System;
using DoFest.Entities.Authentication;

namespace DoFest.Business.Models.Authentication
{
    public sealed class StudentModel
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int Year { get; set; }

        public Guid? CityId { get; set; }

        public User User { get; set; }
    }
}
