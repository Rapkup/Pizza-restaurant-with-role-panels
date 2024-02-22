using DAL.DB_Contexts;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace WEBKITTER.UI.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {

        
            public AppDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var builder = new DbContextOptionsBuilder<AppDbContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection"); // Update with your connection string name
                builder.UseSqlServer(connectionString);

                return new AppDbContext(builder.Options);
            }
        

    }
}
