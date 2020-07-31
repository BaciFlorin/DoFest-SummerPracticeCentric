using AutoMapper;
using DoFest.Business.Identity.Models;
using DoFest.Entities.Authentication;

namespace DoFest.Business.Identity
{
    /// <summary>
    /// Profil de mapping intre modelele si entitati.
    /// </summary>
    public class AuthenticationMappingProfile: Profile
    {
        public AuthenticationMappingProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserType, UserTypeModel>();
        }
    }
}
