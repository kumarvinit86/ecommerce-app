using AuthService.Contracts.Inbound.Query;
using AuthService.Contracts.Outbound.Query;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.Repositories.Query;
using CommunityToolkit.Diagnostics;

namespace AuthService.Application.Queries.Services
{
    public class OrganizationQueryService : IOrganizationQueryService
    {
        private readonly IOrganizationReadRepository organizationReadRepository;

        public OrganizationQueryService(IOrganizationReadRepository organizationReadRepository)
        {
            Guard.IsNotNull(organizationReadRepository, nameof(organizationReadRepository));
            this.organizationReadRepository = organizationReadRepository ?? throw new ArgumentNullException(nameof(organizationReadRepository));
        }


        public async Task<IEnumerable<Organization>> GetAllOrganizationsAsync()
        {
            return await organizationReadRepository.GetAllAsync();
        }

        public async Task<Organization?> GetOrganizationByIdAsync(Guid organizationId)
        {
            return await organizationReadRepository.GetByIdAsync(organizationId);
        }

    }
}
