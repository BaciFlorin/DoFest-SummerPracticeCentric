using DoFest.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoFest.IntegrationTests.Shared.Extensions
{
    public static class UserTypeExtension
    {
        public static UserType WithName(this UserType user, string name)
        {
            return new UserType(
                name,
                user.Description
                );
        }
    }
}
