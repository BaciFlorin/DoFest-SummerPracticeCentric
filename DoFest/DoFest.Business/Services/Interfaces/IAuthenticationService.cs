using System.Threading.Tasks;
using DoFest.Business.Models.Authentication;

namespace DoFest.Business.Services.Interfaces
{
    /// <summary>
    /// Defineste contractul folosit de un serviciu de autentificare.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Realizeaza login-ul pentru un utilizator.
        /// </summary>
        /// <param name="loginModel"> Model de data pentru login. </param>
        /// <returns> ?????? </returns>
        Task Login(LoginModel loginModel);

        /// <summary>
        /// Realizeaza register-ul pentru un utilizator
        /// </summary>
        /// <param name="registerModel">  Model de data pentru register. </param>
        /// <returns> ????? </returns>
        Task Register(RegisterModel registerModel);

        /// <summary>
        /// Poate schimba parola unui user existent in baza de date.
        /// </summary>
        /// <param name="newPasswordModel"> Model de data pentru schimbarea parolei. </param>
        /// <returns> ????? </returns>
        Task ChangePassword(NewPasswordModel newPasswordModel);
    }
}
