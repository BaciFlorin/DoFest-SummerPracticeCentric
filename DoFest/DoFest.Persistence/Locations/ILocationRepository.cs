using DoFest.Entities.Activities.Places;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoFest.Persistence.Locations
{
    public interface ILocationRepository : IRepository<Location>
    {
        public Task<IList<Location>> GetLocations();
    }
}
