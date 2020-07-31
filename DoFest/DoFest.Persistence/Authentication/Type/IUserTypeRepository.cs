using System.Collections.Generic;
using System.Threading.Tasks;
using DoFest.Entities.Authentication;

namespace DoFest.Persistence.Authentication.Type
{
    public interface IUserTypeRepository: IRepository<UserType>
    {
        Task<UserType> GetByName(string name);

        Task<IList<UserType>> GetAll();
    }
}