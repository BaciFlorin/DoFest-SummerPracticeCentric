using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DoFest.Business.Errors;
using DoFest.Business.Identity.Models;
using DoFest.Business.Identity.Services.Interfaces;
using DoFest.Entities.Authentication;
using DoFest.Entities.Lists;
using DoFest.Persistence.Activities.Places;
using DoFest.Persistence.Authentication;
using DoFest.Persistence.Authentication.Type;
using DoFest.Persistence.BucketLists;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DoFest.Business.Identity.Services.Implementations
{
    public sealed class AuthenticationService: IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly JwtOptions _config;
        private readonly ICityRepository _cityRepository;
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IHttpContextAccessor _accessor;
        private readonly IBucketListsRepository _bucketListRepository;

        public AuthenticationService(
            IOptions<JwtOptions> config, 
            IPasswordHasher passwordHasher, 
            IUserRepository userRepository,
            IUserTypeRepository userTypeRepository, 
            ICityRepository cityRepository,
            IStudentRepository studentRepository, 
            IHttpContextAccessor accessor,
            IBucketListsRepository bucketListRepository)
        {
            _config = config.Value;
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _userTypeRepository = userTypeRepository;
            _cityRepository = cityRepository;
            _studentRepository = studentRepository;
            _accessor = accessor;
            _bucketListRepository = bucketListRepository;
        }


        public async Task<Result<LoginModelResponse, Error>> Login(LoginModelRequest loginModelRequest)
        {
            var user = await _userRepository.GetByEmail(loginModelRequest.Email);
            if (user == null)
                return Result.Failure<LoginModelResponse, Error>(ErrorsList.UserNotFound);

            if (!_passwordHasher.Check(user.PasswordHash, loginModelRequest.Password))
                return Result.Failure<LoginModelResponse, Error>(ErrorsList.InvalidPassword);

            return Result.Success<LoginModelResponse, Error>(await GenerateToken(user));
        }

        public async Task<Result<UserModel, Error>> Register(RegisterModel registerModel)
        {
            var user = await _userRepository.GetByEmail(registerModel.Email);
            if (user != null)
                return Result.Failure<UserModel,Error>(ErrorsList.EmailExists);

            user = await _userRepository.GetByUsername(registerModel.Username);
            if (user != null)
                return Result.Failure<UserModel, Error>(ErrorsList.UsernameExists);

            var city = await _cityRepository.GetById(registerModel.City);
            if (city == null)
                return Result.Failure<UserModel, Error>(ErrorsList.InvalidCity);

            var userType = await _userTypeRepository.GetById(registerModel.UserType); 
            if(userType == null)
                return Result.Failure<UserModel, Error>(ErrorsList.InvalidUserType);

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

            var newBucketList = new BucketList()
            {
                Name = registerModel.BucketListName,
                UserId = newUser.Id
            };
            await _bucketListRepository.Add(newBucketList);
            await _bucketListRepository.SaveChanges();

            return Result.Success<UserModel, Error>(UserModel.Create(newUser.Id, newUser.Username, newUser.Email, userType.Name, newUser.StudentId.GetValueOrDefault(), newBucketList.Id));
        }

        public async Task<Result<string, Error>> ChangePassword(NewPasswordModelRequest newPasswordModelRequest)
        {
            var id = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var user = await _userRepository.GetById(id);
            var samePassword = _passwordHasher.Check(user.PasswordHash, newPasswordModelRequest.NewPassword);
            if (samePassword)
            {
                return Result.Failure<string, Error>(ErrorsList.SamePassword);
            }
            user.PasswordHash = _passwordHasher.CreateHash(newPasswordModelRequest.NewPassword);
            
            _userRepository.Update(user);
            await _userRepository.SaveChanges();

            return Result.Success<string, Error>("Password changed!");
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

            var type = await _userTypeRepository.GetById(user.UserTypeId);

            return new LoginModelResponse(user.Username, user.Email, new JwtSecurityTokenHandler().WriteToken(token), user.StudentId.GetValueOrDefault(), type.Name == "Admin");
        }
    }
}
