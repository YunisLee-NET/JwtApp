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

        //Her iki variant uygundur.
        public DbSet<AppUser> AppUsers => this.Set<AppUser>();
        public DbSet<AppRole> AppRoles => this.Set<AppRole>();
        public DbSet<Category> Categories { get { return this.Set<Category>(); } }
        public DbSet<Product> Products { get { return this.Set<Product>(); } }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
