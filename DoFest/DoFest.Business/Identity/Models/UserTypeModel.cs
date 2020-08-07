using System;

namespace DoFest.Business.Identity.Models
{
    public class UserTypeModel
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }
    }
}