using System;
using System.Threading.Tasks;
using DoFest.Entities.Authentication;

namespace DoFest.Persistence.Authentication
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetUserById(Guid id);

        Task AddUser(User userEntity);
    }
}
