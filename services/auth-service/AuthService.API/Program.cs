using AuthService.API;
using AuthService.API.SwaggerConfiguration.ModelSamples;
using AuthService.Infrastructure.Seeders;
using AuthService.Infrastructure.SqlDataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthService API", Version = "v1" });
    c.EnableAnnotations();
    c.ExampleFilters();
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddSwaggerExamplesFromAssemblyOf<AuthenticateUserDtoExample>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
// Add DbContext
builder.Services.AddDbContext<AuthDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors(options =>
{
    var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins")
        .GetChildren()
        .Select(x => x.Value)
        .Where(x => x != null) // Filter out null values
        .Cast<string>()        // Cast to non-nullable string
        .ToArray();
    options.AddPolicy("Cors",
        builder =>
        {
            builder.WithOrigins(allowedOrigins)
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructure(); 
builder.Services.AddApiServices();

// Add controllers
builder.Services.AddControllers();

var app = builder.Build();
app.UseCors("Cors");

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
