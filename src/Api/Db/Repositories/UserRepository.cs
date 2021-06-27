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
    public class UserRepository : IUserRepository
    {
        private readonly ApiDotNetDbContext _apiDotNetDbContext;

        public UserRepository(ApiDotNetDbContext apiDotNetDbContext)
        {
            _apiDotNetDbContext = apiDotNetDbContext;
        }

        public async Task<UserEntity> InsertAsync(UserEntity entity)
        {
            var result = await _apiDotNetDbContext.Users.AddAsync(entity);
            await _apiDotNetDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<UserEntity> UpdateAsync(UserEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;
            var result = _apiDotNetDbContext.Users.Update(entity);
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

        public async Task<IEnumerable<UserEntity>> GetAsync(Expression<Func<UserEntity, bool>> predicate)
        {
            return await _apiDotNetDbContext.Users.Where(predicate).ToListAsync();
        }

        public async Task<UserEntity> GetByIdAsync(Guid id)
        {
            return await _apiDotNetDbContext.Users.FindAsync(id);
        }
    }
}