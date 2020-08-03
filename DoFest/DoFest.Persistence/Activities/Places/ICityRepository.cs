using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Entities.Activities.Places;

namespace DoFest.Persistence.Activities.Places
{
    public interface ICityRepository:IRepository<City>
    {
        Task<City> GetByName(string name);

        Task<IList<City>> GetAll();
    }
}