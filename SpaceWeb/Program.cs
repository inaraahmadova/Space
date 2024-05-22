using Microsoft.AspNetCore.Identity;
using SpaceWeb.DataAccesLayer;
using SpaceWeb.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SpaceContext>();

builder.Services.AddIdentity<User, IdentityRole>()
        .AddEntityFrameworkStores<SpaceContext>()
        .AddDefaultTokenProviders();

var app = builder.Build();

app.UseAuthentication();
app.UseStaticFiles();


app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
