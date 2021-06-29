using Api.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Db
{
    public class ApiDotNetDbContext : DbContext
    {
        public ApiDotNetDbContext(DbContextOptions<ApiDotNetDbContext> configuration)
            : base(configuration) {}

        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<CustomerEntity> Customers { get; set; }
        public virtual DbSet<AddressEntity> Adresses { get; set; }
    }
}