using DoFest.IntegrationTests.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoFest.IntegrationTests.Repositories
{
    class IntegrationsTestsDbContext : DbContext
    {
        public IntegrationsTestsDbContext(DbContextOptions<IntegrationsTestsDbContext> options) : base(options)
        {

        }

        public DbSet<FakeUser> Users { get; set; }

    }
}
