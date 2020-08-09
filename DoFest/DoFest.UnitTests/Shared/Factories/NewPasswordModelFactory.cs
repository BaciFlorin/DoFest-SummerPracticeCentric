using DoFest.Business.Identity.Models;

namespace DoFest.UnitTests.Shared.Factories
{
    public class NewPasswordModelFactory
    {
        public static NewPasswordModelRequest Default()
        {
            return new NewPasswordModelRequest()
            {
                NewPassword = "alabalaportocala"
            };
        }
    }
}
