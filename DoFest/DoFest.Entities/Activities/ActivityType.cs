using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoFest.Entities.Activities
{
    [Table("ActivityType")]
    public class ActivityType:Entity
    {
        private ActivityType():base()
        {
            Activities = new List<Activity>();
        }

        public ActivityType(
            string Name
            ) : base()
        {
            this.Name = Name;
            Activities = new List<Activity>();
        }

        [MaxLength(50), Required]
        public string Name { get; private set; }

        public ICollection<Activity> Activities { get; private set; }
    }
}