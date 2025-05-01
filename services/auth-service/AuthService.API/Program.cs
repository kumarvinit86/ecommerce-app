using AuthService.Infrastructure.Seeders;
using AuthService.Infrastructure.SqlDataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthService API", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Add DbContext
builder.Services.AddDbContext<AuthDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add controllers
builder.Services.AddControllers();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthService API v1");
    });
}

// Configure path base before app.Run()
app.UsePathBase("/swagger");

app.UseHttpsRedirection();
app.UseAuthorization();

// Map controllers
app.MapControllers();

try
{
    // Seed Database
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    await DatabaseSeeder.SeedAsync(services);
}
catch (Exception ex)
{
    // Log the exception (you can replace this with a proper logging mechanism)
    Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
    throw;
}
app.Run();
