using AuthService.Contracts.Outbound.Command;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.SqlDataBase;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Repositories.Command
{
    public class RoleWriteRepository : IRoleWriteRepository
    {
        private readonly AuthDbContext dbContext;

        public RoleWriteRepository(AuthDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AssignRoleToUserAsync(Guid userId, Guid roleId)
        {
            var user = await dbContext.Users.FindAsync(userId);
            if (user != null)
            {
                var role = new UserRole
                {
                    UserId = userId,
                    RoleId = roleId
                };

                await dbContext.UserRoles.AddAsync(role);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveRoleFromUserAsync(Guid userId, Guid roleId)
        {
            var role = await dbContext.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

            if (role != null)
            {
                dbContext.UserRoles.Remove(role);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
