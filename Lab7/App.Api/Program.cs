using App.Middlewares;
using App.Models;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
Env.Load();

var databaseProvider = Environment.GetEnvironmentVariable("DATABASE_PROVIDER");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    switch (databaseProvider)
    {
        case "SQLite":
            options.UseSqlite(builder.Configuration.GetConnectionString("SQLite"), o => o.MigrationsAssembly("App.SQLite"));
            break;
        case "SqlServer":
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), o => o.MigrationsAssembly("App.SqlServer"));
            break;
        case "Postgres":
            options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"), o => o.MigrationsAssembly("App.Postgres"));
            break;
        case "InMemory":
            options.UseInMemoryDatabase("InMemory");
            break;
        default:
            throw new InvalidOperationException("Invalid database provider");
    }
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://dev-qyulsuvmi4i083bm.us.auth0.com/";
    options.Audience = "lab6Api";
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Seeder>>();
    var seeder = new Seeder(dbContext, logger);
    seeder.Seed();
}

app.UseMiddleware<TimezoneMiddleware>();
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();