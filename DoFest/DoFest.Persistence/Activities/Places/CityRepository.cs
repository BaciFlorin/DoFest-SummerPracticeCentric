using System.Linq;
using System.Threading.Tasks;
using DoFest.Entities.Activities.Places;
using Microsoft.EntityFrameworkCore;

namespace DoFest.Persistence.Activities.Places
{
    public sealed class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(DoFestContext context) : base(context)
        {
        }

        public async Task<City> GetByName(string name)
            => await context.Cities.Where(city => city.Name == name).FirstOrDefaultAsync();
    }
}