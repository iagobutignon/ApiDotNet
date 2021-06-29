using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Db.Entities;
using Api.Models;
using Api.Models.Requests;

namespace Api.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<CustomerModel> InsertAsync(CustomerInsertRequest request);

        Task<CustomerModel> UpdateAsync(Guid id, CustomerRequest request);

        Task<bool> DeleteAsync(Guid id);

        Task<IEnumerable<CustomerModel>> GetAsync(Expression<Func<CustomerEntity, bool>> predicate);

        Task<CustomerModel> GetByIdAsync(Guid id);
    }
}