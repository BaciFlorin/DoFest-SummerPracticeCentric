using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DoFest.Business.Errors;
using DoFest.Business.Identity.Models;

namespace DoFest.Business.Identity.Services.Interfaces
{
    /// <summary>
    /// Defineste contractul folosit de un serviciu de autentificare.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Realizeaza login-ul pentru un utilizator.
        /// </summary>
        /// <param name="loginModelRequest"> Model de data pentru login. </param>
        /// <returns> ?????? </returns>
        Task<Result<LoginModelResponse, Error>> Login(LoginModelRequest loginModelRequest);

        /// <summary>
        /// Realizeaza register-ul pentru un utilizator
        /// </summary>
        /// <param name="registerModel">  Model de data pentru register. </param>
        /// <returns> ????? </returns>
        Task<Result<string, Error>> Register(RegisterModel registerModel);

        /// <summary>
        /// Poate schimba parola unui user existent in baza de date.
        /// </summary>
        /// <param name="newPasswordModelRequest"> Model de data pentru schimbarea parolei. </param>
        /// <returns> ????? </returns>
        Task<Result<string,Error>> ChangePassword(NewPasswordModelRequest newPasswordModelRequest);
    }
}
