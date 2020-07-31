using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Models.Places;
using DoFest.Business.Activities.Services.Interfaces;
using DoFest.Business.Errors;
using DoFest.Entities.Activities.Places;
using DoFest.Persistence.Activities.Places;

namespace DoFest.Business.Activities.Services.Implementations
{
    public sealed class CityService:ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        public CityService(ICityRepository cityRepository,
            IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
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

            var newCity = new City()
            {
                Name = cityModel.Name
            };
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

            _cityRepository.Delete(city);
            await _cityRepository.SaveChanges();

            return Result.Success<string, Error>("City deleted successfully");
        }
    }
}