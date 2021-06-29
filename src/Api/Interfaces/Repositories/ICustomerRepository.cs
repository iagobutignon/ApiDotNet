using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Db.Entities;

namespace Api.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<CustomerEntity> InsertAsync(CustomerEntity entity);

        Task<CustomerEntity> UpdateAsync(CustomerEntity entity);

        Task<bool> DeleteAsync(Guid id);

        Task<IEnumerable<CustomerEntity>> GetAsync(Expression<Func<CustomerEntity, bool>> predicate);

        Task<CustomerEntity> GetByIdAsync(Guid id);
    }
}