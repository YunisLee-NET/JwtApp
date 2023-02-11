using Microsoft.EntityFrameworkCore;
using Parviz.JwtApp.Back.Core.Domain;
using Parviz.JwtApp.Back.Persistance.Configurations;

namespace Parviz.JwtApp.Back.Persistance.Context
{
    public class JwtContext:DbContext
    {
        public JwtContext(DbContextOptions<JwtContext> options):base(options)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
