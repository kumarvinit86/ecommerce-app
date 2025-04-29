using AuthService.Contracts.Outbound.Command;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.SqlDataBase;
using CommunityToolkit.Diagnostics;


namespace AuthService.Infrastructure.Repositories.Command
{
    public class OrganizationWriteRepository : IOrganizationWriteRepository
    {
        private readonly AuthDbContext dbContext;

        public OrganizationWriteRepository(AuthDbContext dbContext)
        {
            Guard.IsNotNull(dbContext, nameof(dbContext));
            this.dbContext = dbContext;
        }

        public async Task<Guid> CreateAsync(string organizationName, Guid ownerId)
        {
            var organization = new Organization
            {
                Name = organizationName,
                OwnerUserId = ownerId,
                CreatedAt = DateTime.UtcNow
            };

            await dbContext.Organizations.AddAsync(organization);
            await dbContext.SaveChangesAsync();

            return organization.Id;
        }

        public async Task UpdateNameAsync(Guid organizationId, string newName)
        {
            var organization = await dbContext.Organizations.FindAsync(organizationId);
            if (organization != null)
            {
                organization.Name = newName;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DisableAsync(Guid organizationId)
        {
            var organization = await dbContext.Organizations.FindAsync(organizationId);
            if (organization != null)
            {
                organization.IsActive = false;
                await dbContext.SaveChangesAsync();
            }
        }
    }
}

