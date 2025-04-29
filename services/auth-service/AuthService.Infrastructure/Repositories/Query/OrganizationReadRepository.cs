using AuthService.Contracts.Outbound.Query;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.SqlDataBase;
using CommunityToolkit.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Repositories.Query
{
    public class OrganizationReadRepository : IOrganizationReadRepository
    {
        private readonly AuthDbContext dbContext;

        public OrganizationReadRepository(AuthDbContext dbContext)
        {
            Guard.IsNotNull(dbContext, nameof(dbContext));
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Organization>> GetAllAsync()
        { 
            return await dbContext.Organizations.AsNoTracking().ToListAsync();
        }

        public async Task<Organization?> GetByIdAsync(Guid organizationId)
        {
            return await dbContext.Organizations.FindAsync(organizationId);
        }
    }
}
