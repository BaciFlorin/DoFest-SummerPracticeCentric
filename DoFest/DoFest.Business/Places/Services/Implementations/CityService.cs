using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DoFest.Business.Places.Models;
using DoFest.Business.Places.Services.Interfaces;
using DoFest.Persistence.Activities.Places;

namespace DoFest.Business.Places.Services.Implementations
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
    }
}