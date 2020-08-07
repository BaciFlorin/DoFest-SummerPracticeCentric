using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Entities.Authentication;

namespace DoFest.Persistence.Authentication
{
    public interface IUserRepository: IRepository<User>
    {
        Task<IList<User>> GetUsers();

        Task<User> GetByEmail(string email);

        Task<User> GetByUsername(string username);

        Task<User> GetByIdWithUserType(Guid userId);
    }
}