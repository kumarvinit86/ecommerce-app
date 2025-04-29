using AuthService.Domain.Entities;
using AuthService.Infrastructure.Helpers;
using AuthService.Infrastructure.SqlDataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Infrastructure.Seeders
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AuthDbContext>();

            // Apply any pending migrations automatically (optional but good for dev)
            await context.Database.MigrateAsync();

            if (!await context.Roles.AnyAsync())
            {
                var roles = new List<Role>
                            {
                                new Role { Name = "SuperAdmin" },
                                new Role { Name = "Admin" },
                                new Role { Name = "Seller" },
                                new Role { Name = "Customer" }
                            };

                await context.Roles.AddRangeAsync(roles);
                await context.SaveChangesAsync();
            }

            if (!await context.Users.AnyAsync())
            {
                // Default Super Admin User
                var superAdmin = new User
                {
                    Id = Guid.NewGuid(), // Ensure Id is set
                    FullName = "Super Admin",
                    Email = "superadmin@yourapp.com",
                    PasswordHash = Crypto.HashPassword("Super@123"), // Corrected usage of BCrypt
                    IsEmailVerified = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow // Ensure CreatedAt is set
                };

                await context.Users.AddAsync(superAdmin);
                await context.SaveChangesAsync();

                var superAdminRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == "SuperAdmin");

                if (superAdminRole != null)
                {
                    await context.UserRoles.AddAsync(new UserRole
                    {
                        UserId = superAdmin.Id,
                        RoleId = superAdminRole.Id
                    });

                    await context.SaveChangesAsync();
                }
            }
        }
    }

}
