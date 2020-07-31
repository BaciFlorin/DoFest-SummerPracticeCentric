using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DoFest.Business.Activities.Models.Places;
using DoFest.Business.Activities.Services.Interfaces;
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

        public async Task<CityModel> CreateCity(CreateCityModel cityModel)
        {
            var city = await _cityRepository.GetByName(cityModel.Name);
            if (city != null)
            {
                return null;
            }

            var newCity = new City()
            {
                Name = cityModel.Name
            };
            await _cityRepository.Add(newCity);
            await _cityRepository.SaveChanges();

            return _mapper.Map<CityModel>(newCity);
        }

        public async Task<Boolean> DeleteCity(Guid cityId)
        {
            var city = await _cityRepository.GetById(cityId);
            if (city == null)
            {
                return false;
            }

            _cityRepository.Delete(city);
            await _cityRepository.SaveChanges();

            return true;
        }
    }
}