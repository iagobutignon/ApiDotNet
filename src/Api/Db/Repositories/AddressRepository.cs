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
    public class AddressRepository : IAddressRepository
    {
        private readonly ApiDotNetDbContext _apiDotNetDbContext;

        public AddressRepository(ApiDotNetDbContext apiDotNetDbContext)
        {
            _apiDotNetDbContext = apiDotNetDbContext;
        }

        public async Task<AddressEntity> InsertAsync(AddressEntity entity)
        {
            var result = await _apiDotNetDbContext.Adresses.AddAsync(entity);
            await _apiDotNetDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<AddressEntity> UpdateAsync(AddressEntity entity)
        {
            var result = _apiDotNetDbContext.Adresses.Update(entity);
            await _apiDotNetDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                var adresses = await _apiDotNetDbContext.Adresses.ToListAsync();
                adresses.Remove(entity);
                await _apiDotNetDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<AddressEntity>> GetAsync(Expression<Func<AddressEntity, bool>> predicate)
        {
            return await _apiDotNetDbContext.Adresses.Where(predicate).ToListAsync();
        }

        public async Task<AddressEntity> GetByIdAsync(Guid id)
        {
            return await _apiDotNetDbContext.Adresses.FindAsync(id);
        }
    }
}