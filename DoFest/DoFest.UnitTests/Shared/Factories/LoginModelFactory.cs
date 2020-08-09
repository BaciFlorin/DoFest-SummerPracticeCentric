
using DoFest.Business.Identity.Models;

namespace DoFest.UnitTests.Shared.Factories
{
    public class LoginModelFactory
    {
        public static LoginModelRequest Default()
        {
            return new LoginModelRequest()
            {
                Email = "bacica.florin@gmail.com",
                Password = "florinel"
            };
        }
    }
}
