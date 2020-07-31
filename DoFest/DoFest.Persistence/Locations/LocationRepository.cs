using DoFest.Entities.Activities.Places;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoFest.Persistence.Locations
{
    public sealed class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(DoFestContext context) : base(context)
        {

        }
        public async Task<IList<Location>> GetLocations()
        => await context
            .Locations
            .ToListAsync();
    }
}
