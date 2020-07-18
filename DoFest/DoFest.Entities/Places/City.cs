using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoFest.Entities.Authentication;

namespace DoFest.Entities.Places
{
    [Table("City")]
    public class City:Entity
    {
        public City():base()
        {
            Students = new List<Student>();
            Locations = new List<Location>();
        }
        
        [Required, MaxLength(50)]
        public string Name { get;  set; }

        public ICollection<Student> Students { get;  set; }

        public ICollection<Location> Locations { get; set; }
    }
}