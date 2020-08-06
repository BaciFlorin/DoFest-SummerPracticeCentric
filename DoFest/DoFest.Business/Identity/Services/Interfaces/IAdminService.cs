using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DoFest.Business.Errors;
using DoFest.Business.Identity.Models;
using DoFest.Entities.Authentication;

namespace DoFest.Business.Identity.Services.Interfaces
{
    public interface IAdminService
    {
        Task<Result<IList<UserModel>, Error>> GetUsers();

        Task<Result<IList<UserTypeModel>, Error>> GetUserTypes();

        Task<Result<UserModel, Error>> ToggleUserType(Guid userId);

    }
}
