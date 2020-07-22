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
            // ****** Mapare pentru entatatile user si student in modele. ******
            CreateMap<User, UserModel>();
            CreateMap<Student, StudentModel>();

            // ????
            CreateMap<LoginModel, User>();
            CreateMap<RegisterModel, User>();
        }
    }
}
