namespace DoFest.Business.Models.Authentication
{
    public sealed class LoginModel
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
