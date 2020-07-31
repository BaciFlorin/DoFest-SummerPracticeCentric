using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoFest.Entities.Authentication;
using Microsoft.EntityFrameworkCore;

namespace DoFest.Persistence.Authentication.Type
{
    public sealed class UserTypeRepository: Repository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(DoFestContext context) : base(context)
        {
        }

        public async Task<UserType> GetByName(string name)
            => await context.UserTypes.Where(userType => userType.Name == name).FirstOrDefaultAsync();

        public async Task<IList<UserType>> GetAll()
            => await context.UserTypes.ToListAsync();
    }
}