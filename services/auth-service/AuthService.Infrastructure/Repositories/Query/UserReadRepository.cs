using AuthService.Contracts.Outbound.Query;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.SqlDataBase;
using CommunityToolkit.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Repositories.Query
{
    public class UserReadRepository : IUserReadRepository
    {
        private readonly AuthDbContext _dbContext;
        public UserReadRepository(AuthDbContext dbContext)
        {
            Guard.IsNotNull(dbContext, nameof(dbContext));
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users.AsNoTrackingWithIdentityResolution().ToListAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByIdAsync(Guid userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }

        public async Task<List<string>> GetRolesAsync(Guid userId)
        {
            var roles = await _dbContext.UserRoles.AsNoTracking()
                .Where(ur => ur.UserId == userId)
                .Select(ur => ur.Role.Name)
                .ToListAsync();
            return roles;
        }
    }
}
