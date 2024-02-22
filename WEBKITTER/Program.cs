using BLL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WEBKITTER.UI.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ConfigureBLL(builder.Configuration.GetConnectionString("DefaultConnection")!);


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer((builder.Configuration.GetConnectionString("DefaultConnection")));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<SignInManager<ApplicationUser>>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ClientPolicy", policy => policy.RequireRole("Client"));
    options.AddPolicy("AdministratorPolicy", policy => policy.RequireRole("Administrator"));
    options.AddPolicy("ClientManagerPolicy", policy => policy.RequireRole("ClientManager"));
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

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.LoginPath = "/Home/Login";
        options.AccessDeniedPath = "/Home/Index";
        options.SlidingExpiration = true;
        options.ReturnUrlParameter = string.Empty;
    });



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("cors");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
