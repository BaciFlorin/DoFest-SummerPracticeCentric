using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoFest.Entities.Authentication.Notification
{
    [Table("Notification")]
    public class Notification:Entity
    {
        public Notification():base()
        {
            
        }

        [Required]
        public Guid? UserId { get; set; }
        public User User { get; set; }

        [DataType(DataType.DateTime), Required]
        public DateTime Date { get; set; }

        [Required, MaxLength(1000)]
        public string Description { get; set; }
    }
}