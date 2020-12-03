using CA.ProductCoreApp.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using CA.ProductCoreApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CA.ProductCoreApp.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class ProductContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\MSSQLSERVER2017; database=ProductCoreApp; user id= sa; password=1; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new AppRoleMap());
            modelBuilder.ApplyConfiguration(new AppUserRoleMap());
            modelBuilder.ApplyConfiguration(new AppUserRoleMap());
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
