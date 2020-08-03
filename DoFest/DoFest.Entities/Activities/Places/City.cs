using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoFest.Entities.Authentication;

namespace DoFest.Entities.Activities.Places
{
    [Table("City")]
    public class City:Entity
    {
        public City():base()
        {
            Students = new List<Student>();
            Activities = new List<Activity>();
        }
        
        [Required, MaxLength(100)]
        public string Name { get;  set; }

        public ICollection<Student> Students { get;  set; }

        public ICollection<Activity> Activities { get; set; }
    }
}