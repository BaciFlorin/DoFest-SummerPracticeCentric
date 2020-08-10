using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DoFest.Entities.Authentication
{
    [Table("Student")]
    public class Student:Entity
    {
        private Student() : base()
        {
        }

        public Student(
            string Name,
            int Age,
            int Year,
            Guid CityId
            ) : base()
        {
            this.Age = Age;
            this.Name = Name;
            this.Year = Year;
            this.CityId = CityId;
        }

        [Required, MaxLength(150)]
        public string Name { get; private set; }

        [Required, Range(18,99)]
        public int Age { get; private set; }

        [Required, Range(1,6),DefaultValue(1)]
        public int Year { get; private set; }

        [AllowNull]
        public Guid? CityId { get; private set; }

    }
}