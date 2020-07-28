using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoFest.Entities.Activities
{
    [Table("ActivityType")]
    public class ActivityType:Entity
    {
        public ActivityType():base()
        {
            Activities = new List<Activity>();
        }

        [MaxLength(50), Required]
        public string Name { get; set; }

        public ICollection<Activity> Activities { get; set; }
    }
}