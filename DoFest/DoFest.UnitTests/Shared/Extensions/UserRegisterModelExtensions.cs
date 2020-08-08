using DoFest.Business.Identity.Models;

namespace DoFest.UnitTests.Shared.Extensions
{
    public static class UserRegisterModelExtensions
    {
        public static RegisterModel WithEmail(this RegisterModel model, string email)
        {
            model.Email = email;
            return model;
        }

        public static RegisterModel WithUsername(this RegisterModel model, string username)
        {
            model.Username = username;
            return model;
        }
    }
}
}
