using System;
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

        /// <summary>
        /// Se creeaza un query pentru a gasi userul cu id-ul dat ca parametru.
        /// </summary>
        /// <param name="id"> Id-ul userului cautat. </param>
        /// <returns> Un task ce contine o entitate User.</returns>
        public async Task<User> GetUserById(Guid id)
            => await context.Users
                .FirstAsync(user => user.Id == id);

        /// <summary>
        /// Se adauga un user nou in database.
        /// </summary>
        /// <param name="userEntity"> O entitate de tip User ce va fi inserata.</param>
        /// <returns></returns>
        public async Task AddUser(User userEntity)
            => await context.Users.AddAsync(userEntity);
    }
}
