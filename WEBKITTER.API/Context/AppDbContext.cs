using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WEBKITTER.API.Models.Roles;

namespace WEBKITTER.API.Context
{

    public sealed class AppDbContext : IdentityDbContext<ApplicationUser>
    {


        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().HasNoKey().ToView("Clients");
            modelBuilder.Entity<Admin>().HasNoKey().ToView("Administrators");
            modelBuilder.Entity<Manager>().HasNoKey().ToView("ClientManagers");
        }


        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Manager> Managers { get; set; }
    }


}
