using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Db.Entities;

namespace Api.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> InsertAsync(UserEntity entity);

        Task<UserEntity> UpdateAsync(UserEntity entity);

        Task<bool> DeleteAsync(Guid id);

        Task<IEnumerable<UserEntity>> GetAsync(Expression<Func<UserEntity, bool>> predicate);

        Task<UserEntity> GetByIdAsync(Guid id);
    }
}