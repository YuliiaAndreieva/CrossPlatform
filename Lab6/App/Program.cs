using App.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var databaseProvider = builder.Configuration["DatabaseProvider"];
builder.Services.AddDbContext<AppDbContext>(options =>
{
    switch (databaseProvider)
    {
        case "Sqlite":
            options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"), o => o.MigrationsAssembly("App.Sqlite"));
            break;
        default:
            throw new InvalidOperationException("Invalid database provider");
    }
});

builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://dev-qyulsuvmi4i083bm.us.auth0.com/";
    options.Audience = "lab6Api";
});
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();