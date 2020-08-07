using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Models.Places;
using DoFest.Business.Errors;

namespace DoFest.Business.Activities.Services.Interfaces
{
    public interface ICityService
    {
        Task<IList<CityModel>> GetAllCities();
        Task<Result<CityModel, Error>> CreateCity(CreateCityModel cityModel);
        Task<Result<string, Error>> DeleteCity(Guid cityId);
    }
}