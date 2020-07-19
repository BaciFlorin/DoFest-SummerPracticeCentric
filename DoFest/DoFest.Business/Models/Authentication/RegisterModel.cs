namespace DoFest.Business.Models.Authentication
{
    public sealed class RegisterModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
