using DAL.DB_Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
/*    public class EntityContextFactory : IDesignTimeDbContextFactory<EntityContext>
    {
        public EntityContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder();
            //установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            //Получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            //создаем конфигурацию
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<EntityContext>();
            DbContextOptions<EntityContext> options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            return new EntityContext(optionsBuilder.Options);
        }
    }*/
}
