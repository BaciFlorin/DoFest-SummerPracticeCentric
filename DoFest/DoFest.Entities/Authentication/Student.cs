using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoFest.Entities.Authentication
{
    [Table("Student")]
    public class Student:Entity
    {
        public Student():base()
        {
           
        }

        [Required, MaxLength(50)]
        public string Name { get;  set; }

        [Required, Range(18,99)]
        public int Age { get;  set; }

        [Required, Range(1,6),DefaultValue(1)]
        public int Year { get;  set; }

        [Required]
        public Guid CityId { get; set; }

    }
}