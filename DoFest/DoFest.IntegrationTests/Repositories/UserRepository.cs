using DoFest.Entities.Authentication;
using DoFest.IntegrationTests.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DoFest.IntegrationTests.Repositories
{
    internal class UserRepository
    {
        private readonly IntegrationsTestsDbContext context;

        public UserRepository(IntegrationsTestsDbContext context)
        {
            this.context = context;
        }

        public async Task<FakeUser> GetByEmail(string email)
            => await this.context.Set<FakeUser>().FirstOrDefaultAsync(x => x.Email == email);

        public void Update(FakeUser entity)
            => this.context.Set<FakeUser>().Update(entity);

        public Task SaveChanges()
            => this.context.SaveChangesAsync();
    }
}
