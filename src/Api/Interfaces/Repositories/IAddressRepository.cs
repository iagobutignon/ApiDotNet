using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Db.Entities;

namespace Api.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<AddressEntity> InsertAsync(AddressEntity entity);

        Task<AddressEntity> UpdateAsync(AddressEntity entity);

        Task<bool> DeleteAsync(Guid id);

        Task<IEnumerable<AddressEntity>> GetAsync(Expression<Func<AddressEntity, bool>> predicate);

        Task<AddressEntity> GetByIdAsync(Guid id);
    }
}