using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using DoFest.Business.Errors;
using DoFest.Business.Identity.Models;
using DoFest.Business.Identity.Services.Interfaces;
using DoFest.Persistence.Authentication;
using DoFest.Persistence.Authentication.Type;
using Microsoft.AspNetCore.Http;

namespace DoFest.Business.Identity.Services.Implementations
{
    public sealed class AdminService: IAdminService
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        private readonly IUserRepository _userRepository;
        private readonly IUserTypeRepository _userTypeRepository;


        public AdminService(
            IMapper mapper,
            IHttpContextAccessor accessor,
            IUserRepository userRepository,
            IUserTypeRepository userTypeRepository
            )
        {
            this._mapper = mapper;
            this._accessor = accessor;
            this._userRepository = userRepository;
            this._userTypeRepository = userTypeRepository;
        }

        public async Task<Result<IList<UserModel>, Error>> GetUsers()
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var user = await _userRepository.GetById(userId);
            var userType = await _userTypeRepository.GetById(user.UserTypeId);
            return userType.Name != "Admin" ? 
                Result.Failure<IList<UserModel>, Error>(ErrorsList.UnauthorizedUser) 
                : _mapper.Map<List<UserModel>>(await _userRepository.GetUsers());
        }

        public async Task<Result<IList<UserTypeModel>, Error>> GetUserTypes()
        {
            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var user = await _userRepository.GetById(userId);
            var userType = await _userTypeRepository.GetById(user.UserTypeId);
            return userType.Name != "Admin" ? 
                Result.Failure<IList<UserTypeModel>, Error>(ErrorsList.UnauthorizedUser) 
                : _mapper.Map<List<UserTypeModel>>(await _userTypeRepository.GetAll());
        }

        public async Task<Result<UserModel, Error>> ToggleUserType(Guid userId)
        {
            var requestingUserId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var requestingUser = await _userRepository.GetById(requestingUserId);
            var requestingUserType = await _userTypeRepository.GetById(requestingUser.UserTypeId);
            if (requestingUserType.Name != "Admin")
            {
                return Result.Failure<UserModel, Error>(ErrorsList.UnauthorizedUser);
            }

            var user = await _userRepository.GetById(userId);
            var userTypesDictionary = (await _userTypeRepository.GetAll()).ToDictionary(x => x.Name, x => x.Id);

            user.UpdateUserType(user.UserTypeId == userTypesDictionary["Admin"] 
                ? userTypesDictionary["Normal user"] 
                : userTypesDictionary["Admin"]);
            
            _userRepository.Update(user);

            await _userRepository.SaveChanges();
            
            return _mapper.Map<UserModel>(user);
        }

    }
}
