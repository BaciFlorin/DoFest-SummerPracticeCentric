using System.Linq;
using System.Threading.Tasks;
using DoFest.Entities.Authentication;
using Microsoft.EntityFrameworkCore;

namespace DoFest.Persistence.Authentication
{
    public sealed class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(DoFestContext context) : base(context)
        {
        }

        public async Task<User> GetByEmail(string email) 
            => await context.Users.Where(user => user.Email == email).FirstOrDefaultAsync();

        public async Task<User> GetByUsername(string username)
            => await context.Users.Where(user => user.Username == username).FirstOrDefaultAsync();
    }
}
