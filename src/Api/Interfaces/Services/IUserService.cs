using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Db.Entities;
using Api.Models;
using Api.Models.Requests;

namespace Api.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserModel> InsertAsync(UserRequest request);

        Task<UserModel> UpdateAsync(Guid id, UserRequest request);

        Task<bool> DeleteAsync(Guid id);

        Task<IEnumerable<UserModel>> GetAsync(Expression<Func<UserEntity, bool>> predicate);

        Task<UserModel> GetByIdAsync(Guid id);

        Task<UserModel> PasswordSignInAsync(string userName, string password);
    }
}