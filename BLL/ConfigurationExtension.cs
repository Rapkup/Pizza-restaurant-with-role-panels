using DAL.Models;
using DAL;
using Microsoft.Extensions.DependencyInjection;
using BLL.DTO;
using BLL.Services;
using BLL.Interfaces;
using BLL.Profilers;

namespace BLL
{
    public static class ConfigurationExtension
    {
        public static void ConfigureBLL(this IServiceCollection services, string connection)
        {
            services.ConfigureDAL(connection);
            services.AddAutoMapper(
                    typeof(EntitysProfile)/*,
                    typeof(DishProfile),
                    typeof(OrderProfile)*/
            );

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IDishService, DishService>();
            services.AddTransient<IOrderService, OrderService>();
        }



    }
}
