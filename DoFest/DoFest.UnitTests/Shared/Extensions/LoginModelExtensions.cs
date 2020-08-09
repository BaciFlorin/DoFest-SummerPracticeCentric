using DoFest.Business.Identity.Models;
using System.Runtime.CompilerServices;

namespace DoFest.UnitTests.Shared.Extensions
{
    public static class LoginModelExtensions
    {
        public static LoginModelRequest WithEmail(this LoginModelRequest loginModel, string email)
        {
            loginModel.Email = email;
            return loginModel;
        }

        public static LoginModelRequest WithPassword(this LoginModelRequest loginModel, string password)
        {
            loginModel.Password = password;
            return loginModel;
        }
    }
}
