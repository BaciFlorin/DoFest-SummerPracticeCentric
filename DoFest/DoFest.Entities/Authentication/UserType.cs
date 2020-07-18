using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoFest.Entities.Authentication
{
    [Table("UserType")]
    public class UserType:Entity
    {
        public UserType():base()
        {
            Users = new List<User>();
        }

        [Required, MaxLength(50)]
        public string Name { get;  set; }

        [Required, MaxLength(200)]
        public string Description { get;  set; }

        public ICollection<User> Users { get;  set; }
    }
}