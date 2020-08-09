using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Models.Places;
using DoFest.Business.Activities.Services.Interfaces;
using DoFest.Business.Errors;
using DoFest.Entities.Activities.Places;
using DoFest.Persistence.Activities.Places;
using DoFest.Persistence.Authentication;
using DoFest.Persistence.Authentication.Type;
using Microsoft.AspNetCore.Http;

namespace DoFest.Business.Activities.Services.Implementations
{
    public sealed class CityService:ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        private readonly IUserRepository _userRepository;
        private readonly IUserTypeRepository _userTypeRepository;

        public CityService(ICityRepository cityRepository, IMapper mapper, IHttpContextAccessor accessor,
            IUserRepository userRepository, IUserTypeRepository userTypeRepository)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
            _accessor = accessor;
            _userRepository = userRepository;
            _userTypeRepository = userTypeRepository;
        }

        public async Task<IList<CityModel>> GetAllCities()
        {
            var cities = await _cityRepository.GetAll();
            return _mapper.Map<IList<CityModel>>(cities);
        }

        public async Task<Result<CityModel, Error>> CreateCity(CreateCityModel cityModel)
        {
            var city = await _cityRepository.GetByName(cityModel.Name);
            if (city != null)
            {
                return Result.Failure<CityModel,Error>(ErrorsList.ExistingCity);
            }

            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var user = await _userRepository.GetById(userId);
            var userType = await _userTypeRepository.GetByName("Admin");
            if (user.UserTypeId != userType.Id)
            {
                return Result.Failure<CityModel, Error>(ErrorsList.UnauthorizedUser);
            }

            var newCity = new City(cityModel.Name);
            await _cityRepository.Add(newCity);
            await _cityRepository.SaveChanges();

            return Result.Success<CityModel, Error>(_mapper.Map<CityModel>(newCity));
        }

        public async Task<Result<string, Error>> DeleteCity(Guid cityId)
        {
            var city = await _cityRepository.GetById(cityId);
            if (city == null)
            {
                return Result.Failure<string,Error>(ErrorsList.InvalidCity);
            }

            var userId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var user = await _userRepository.GetById(userId);
            var userType = await _userTypeRepository.GetByName("Admin");
            if (user.UserTypeId != userType.Id)
            {
                return Result.Failure<string, Error>(ErrorsList.UnauthorizedUser);
            }

            _cityRepository.Delete(city);
            await _cityRepository.SaveChanges();

            return Result.Success<string, Error>("City deleted successfully");
        }
    }
}