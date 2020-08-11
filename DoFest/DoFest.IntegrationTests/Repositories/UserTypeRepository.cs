using DoFest.Entities.Authentication;
using DoFest.IntegrationTests.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DoFest.IntegrationTests.Repositories
{
    internal class UserTypeRepository
    {
        private readonly IntegrationTestsDbConextUserType context;

        public UserTypeRepository(IntegrationTestsDbConextUserType context)
        {
            this.context = context;
        }

        public async Task<UserType> GetByName(string name)
            => await this.context.Set<UserType>().FirstOrDefaultAsync(x => x.Name == name);

        public void Update(UserType entity)
            => this.context.Set<UserType>().Update(entity);

        public Task SaveChanges()
            => this.context.SaveChangesAsync();
    }
}
