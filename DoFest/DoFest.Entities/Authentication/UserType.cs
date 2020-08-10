using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoFest.Entities.Authentication
{
    [Table("UserType")]
    public class UserType:Entity
    {
        private UserType():base()
        {
            Users = new List<User>();
        }

        public UserType(
            string Name,
            string Description
            ) : base()
        {
            this.Name = Name;
            this.Description = Description;
            Users = new List<User>();
        }

        [Required, MaxLength(100)]
        public string Name { get; private set; }

        [Required, MaxLength(200)]
        public string Description { get; private set; }

        public ICollection<User> Users { get; private set; }

    }
}