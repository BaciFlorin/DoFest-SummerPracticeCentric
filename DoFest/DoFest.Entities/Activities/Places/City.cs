using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoFest.Entities.Authentication;

namespace DoFest.Entities.Activities.Places
{
    [Table("City")]
    public class City:Entity
    {
        private City():base()
        {
            Students = new List<Student>();
            Activities = new List<Activity>();
        }

        public City(
            string Name
            ) : base()
        {
            this.Name = Name;
            Students = new List<Student>();
            Activities = new List<Activity>();
        }

        [Required, MaxLength(100)]
        public string Name { get; private set; }

        public ICollection<Student> Students { get; private set; }

        public ICollection<Activity> Activities { get; private set; }
    }
}