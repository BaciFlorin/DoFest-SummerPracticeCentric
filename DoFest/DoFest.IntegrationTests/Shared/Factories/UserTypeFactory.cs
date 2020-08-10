using DoFest.Entities.Authentication;

namespace DoFest.IntegrationTests.Shared.Factories
{
    public static class UserTypeFactory
    {
        public static UserType Default()
        {
            return new UserType("Normal user", "access");
        }
    }
}
