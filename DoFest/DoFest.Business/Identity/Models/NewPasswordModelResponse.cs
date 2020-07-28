namespace DoFest.Business.Identity.Models
{
    public sealed class NewPasswordModelResponse
    {
        public NewPasswordModelResponse(string passwordHash)
        {
            PasswordHash = passwordHash;
        }
        public string PasswordHash { get; private set; }
    }
}