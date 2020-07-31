using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Business.Places.Models;

namespace DoFest.Business.Places.Services.Interfaces
{
    public interface ICityService
    {
        Task<IList<CityModel>> GetAllCities();
    }
}