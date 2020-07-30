using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DoFest.Business.Identity.Models;
using DoFest.Business.Identity.Services.Interfaces;
using DoFest.Entities.Authentication;
using DoFest.Persistence.Activities.Places;
using DoFest.Persistence.Authentication;
using DoFest.Persistence.Authentication.Type;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DoFest.Business.Identity.Services.Implementations
{
    public sealed class AuthenticationService: IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly JwtOptions _config;
        private readonly ICityRepository _cityRepository;
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IHttpContextAccessor _accessor;

        public AuthenticationService(IMapper mapper,
            IOptions<JwtOptions> config, 
            IPasswordHasher passwordHasher, 
            IUserRepository userRepository,
            IUserTypeRepository userTypeRepository, 
            ICityRepository cityRepository,
            IStudentRepository studentRepository, 
            IHttpContextAccessor accessor)
        {
            _mapper = mapper;
            _config = config.Value;
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _userTypeRepository = userTypeRepository;
            _cityRepository = cityRepository;
            _studentRepository = studentRepository;
            _accessor = accessor;
        }


        public async Task<LoginModelResponse> Login(LoginModelRequest loginModelRequest)
        {
            var user = await _userRepository.GetByEmail(loginModelRequest.Email);

            return user == null || !_passwordHasher.Check(user.PasswordHash, loginModelRequest.Password) ? null : await GenerateToken(user);
        }

        public async Task<UserModel> Register(RegisterModel registerModel)
        {
            var user = await _userRepository.GetByEmail(registerModel.Email);
            if (user != null)
                return null;

            user = await _userRepository.GetByUsername(registerModel.Username);
            if (user != null)
                return null;

            var city = await _cityRepository.GetByName(registerModel.City);
            var userType = await _userTypeRepository.GetByName(registerModel.UserType);
            if (city == null || userType == null)
            {
                return null;
            }

            var newStudent = new Student()
            {
                Age = registerModel.Age,
                CityId = city.Id,
                Name = registerModel.Name,
                Year = registerModel.Year
            };
            await _studentRepository.Add(newStudent);
            await _studentRepository.SaveChanges();

            var newUser = new User()
            {
                Username = registerModel.Username,
                Email = registerModel.Email,
                PasswordHash = _passwordHasher.CreateHash(registerModel.Password),
                StudentId = newStudent.Id,
                UserTypeId = userType.Id
            };
            await _userRepository.Add(newUser);
            await _userRepository.SaveChanges();

            var returnUser = _mapper.Map<UserModel>(newUser);
            returnUser.UserType = userType.Name;
            return returnUser;
        }

        public async Task<NewPasswordModelResponse> ChangePassword(NewPasswordModelRequest newPasswordModelRequest)
        {
            var id = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var user = await _userRepository.GetById(id);
            user.PasswordHash = _passwordHasher.CreateHash(newPasswordModelRequest.NewPassword);
            
            _userRepository.Update(user);
            await _userRepository.SaveChanges();

            return new NewPasswordModelResponse(user.PasswordHash);
        }

        private async Task<LoginModelResponse> GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var hours = int.Parse(_config.TokenExpirationInHours);

            var token = new JwtSecurityToken(_config.Issuer,
                _config.Audience,
                new List<Claim>()
                {
                    new Claim("userId", user.Id.ToString())
                },
                expires: DateTime.Now.AddHours(hours),
                signingCredentials: credentials);

            var type = await _userTypeRepository.GetById(user.UserTypeId.GetValueOrDefault());

            return new LoginModelResponse(user.Username, user.Email, new JwtSecurityTokenHandler().WriteToken(token), user.StudentId.GetValueOrDefault(), type.Name);
        }
    }
}
