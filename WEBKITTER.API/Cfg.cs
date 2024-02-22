using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using WEBKITTER.API.Context;
using BLL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WEBKITTER.API
{
    public class Cfg
    {

        public static async Task ConfigureAsync(WebApplicationBuilder builder)
        {

            builder.Services.ConfigureBLL(builder.Configuration.GetConnectionString("DefaultConnection")!);

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer((builder.Configuration.GetConnectionString("DefaultConnection")));
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddScoped<SignInManager<ApplicationUser>>();

            var jwtSettings = builder.Configuration.GetSection("JwtSettings");

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.Cookie.Name = "token"; // Название cookie, где будет храниться токен
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Время жизни cookie
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"])),
                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("ClientPolicy", policy => policy.RequireRole("Client"));
                options.AddPolicy("AdministratorPolicy", policy => policy.RequireRole("Administrator"));
                options.AddPolicy("ClientManagerPolicy", policy => policy.RequireRole("ClientManager"));
            });

            builder.Services.AddCors(options =>
          {
              options.AddPolicy("AllowSpecificOrigins",
                  builder =>
                  {
                      //builder.WithOrigins("https://localhost:7134", "https://localhost:44335")
                      builder.AllowAnyOrigin()
                             .AllowAnyHeader()
                             .AllowAnyMethod();
                      //.AllowCredentials();
                  });
          });


            var serviceProvider = builder.Services.BuildServiceProvider();

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Client", "Administrator", "ClientManager" };

            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    // Создать роль, если она не существует
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }

            }

        }
    }
}

