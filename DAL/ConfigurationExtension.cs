using DAL.DB_Contexts;
using DAL.DB_Repositories;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data;

namespace DAL
{
    public static class ConfigurationExtension
    {
        public static void ConfigureDAL(this IServiceCollection services, string connection)
        {
            services.AddDbContext<EntityContext>(options => options.UseSqlServer(connection));


            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IDishRepository, DishRepository>();
        }
    }
}
