using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Business.Activities.Models.Places;

namespace DoFest.Business.Activities.Services.Interfaces
{
    public interface ICityService
    {
        Task<IList<CityModel>> GetAllCities();
        Task<CityModel> CreateCity(CreateCityModel cityModel);
        Task<Boolean> DeleteCity(Guid cityId);
    }
}