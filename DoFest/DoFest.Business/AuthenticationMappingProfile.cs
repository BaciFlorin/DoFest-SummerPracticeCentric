using AutoMapper;
using DoFest.Business.Models.Authentication;
using DoFest.Entities.Authentication;

namespace DoFest.Business
{
    /// <summary>
    /// Profil de mapping intre modelele si entitati.
    /// </summary>
    public class AuthenticationMappingProfile: Profile
    {
        public AuthenticationMappingProfile()
        {
            CreateMap<User, UserModel>();

            CreateMap<LoginModel, User>();

            CreateMap<RegisterModel, User>();
        }
    }
}
