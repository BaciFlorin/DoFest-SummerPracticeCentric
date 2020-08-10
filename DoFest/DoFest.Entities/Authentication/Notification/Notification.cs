using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoFest.Entities.Authentication.Notification
{
    [Table("Notification")]
    public class Notification:Entity
    {
        private Notification():base()
        {

        }

        public Notification(
            Guid ActivityId,
            DateTime Date,
            string Description
            ) : base()
        {
            this.ActivityId = ActivityId;
            this.Date = Date;
            this.Description = Description;
        }


        [Required]
        public Guid ActivityId { get; private set; }

        [DataType(DataType.DateTime), Required]
        public DateTime Date { get; private set; }

        [Required, MaxLength(1000)]
        public string Description { get; private set; }
    }
}