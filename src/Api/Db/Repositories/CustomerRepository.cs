using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Db.Entities;
using Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Db.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApiDotNetDbContext _apiDotNetDbContext;

        public CustomerRepository(ApiDotNetDbContext apiDotNetDbContext)
        {
            _apiDotNetDbContext = apiDotNetDbContext;
        }

        public async Task<CustomerEntity> InsertAsync(CustomerEntity entity)
        {
            var result = await _apiDotNetDbContext.Customers.AddAsync(entity);
            await _apiDotNetDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<CustomerEntity> UpdateAsync(CustomerEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;
            var result = _apiDotNetDbContext.Customers.Update(entity);
            await _apiDotNetDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                entity.Active = false;
                await UpdateAsync(entity);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<CustomerEntity>> GetAsync(Expression<Func<CustomerEntity, bool>> predicate)
        {
            return await _apiDotNetDbContext.Customers.Where(predicate).ToListAsync();
        }

        public async Task<CustomerEntity> GetByIdAsync(Guid id)
        {
            return await _apiDotNetDbContext.Customers.FindAsync(id);
        }
    }
}