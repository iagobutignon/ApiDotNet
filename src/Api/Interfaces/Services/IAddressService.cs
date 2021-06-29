using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Db.Entities;
using Api.Models;
using Api.Models.Requests;

namespace Api.Interfaces.Services
{
    public interface IAddressService
    {
        Task<AddressModel> InsertAsync(AddressRequest request);

        Task<AddressModel> UpdateAsync(Guid id, AddressRequest request);

        Task<bool> DeleteAsync(Guid id);

        Task<IEnumerable<AddressModel>> GetAsync(Expression<Func<AddressEntity, bool>> predicate);

        Task<AddressModel> GetByIdAsync(Guid id);
    }
}