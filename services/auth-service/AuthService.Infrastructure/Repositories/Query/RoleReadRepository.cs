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

        public async Task<List<Role>> GetByIdAsync(Guid userId)
        {
            var role = await (from u in dbContext.Users 
                        join ur in dbContext.UserRoles on u.Id equals ur.UserId
                        join r in dbContext.Roles on ur.RoleId equals r.Id
                        where u.Id == userId
                        select r
                        ).AsNoTracking().ToListAsync();
            if(role is null)
            {
                return new List<Role>();
            }

            return role;
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await dbContext.Roles.AsNoTracking().AnyAsync(r => r.Name == roleName);
        }
    }
}
