using AuthService.Contracts.Outbound.Query;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.SqlDataBase;
using CommunityToolkit.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Repositories.Query
{
    public class RoleReadRepository : IRoleReadRepository
    {
        private readonly AuthDbContext dbContext;

        public RoleReadRepository(AuthDbContext dbContext)
        {
            Guard.IsNotNull(dbContext, nameof(dbContext));
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await dbContext.Roles.AsNoTracking().ToListAsync();
        }

        public async Task<Role> GetByIdAsync(Guid userId)
        {
            var role = await dbContext.Roles.FindAsync(userId);
            Guard.IsNotNull(role, nameof(role)); // Ensure role is not null
            return role;
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await dbContext.Roles.AsNoTracking().AnyAsync(r => r.Name == roleName);
        }
    }
}
