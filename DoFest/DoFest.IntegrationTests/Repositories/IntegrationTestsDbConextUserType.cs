using DoFest.Entities.Authentication;
using DoFest.IntegrationTests.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoFest.IntegrationTests.Repositories
{
    class IntegrationTestsDbConextUserType : DbContext
    {
        public IntegrationTestsDbConextUserType(DbContextOptions<IntegrationTestsDbConextUserType> options) : base(options)
        {

        }

        public DbSet<UserType> UserTypes { get; set; }
    }
}
