using System.Threading.Tasks;
using AutoMapper;
using DoFest.Business.Models.Authentication;
using DoFest.Business.Services.Interfaces;

namespace DoFest.Business.Services.Implementations
{
    public sealed class AuthenticationService: IAuthenticationService
    {
        private readonly IMapper mapper;
        // TODO: adauga repository pentru autentificare

        public AuthenticationService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task Login(LoginModel loginModel)
        {
            throw new System.NotImplementedException();
        }

        public Task Register(RegisterModel registerModel)
        {
            throw new System.NotImplementedException();
        }

        public Task ChangePassword(NewPasswordModel newPasswordModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
