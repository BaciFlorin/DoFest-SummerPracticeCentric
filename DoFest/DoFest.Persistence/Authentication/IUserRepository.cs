using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Entities.Activities;
using DoFest.Entities.Authentication;

namespace DoFest.Persistence.Authentication
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetByEmail(string email);

        Task<User> GetByUsername(string username);
    }
}
