using AuthService.Domain.Entities;

namespace AuthService.Contracts.Inbound.Query;

public interface IOrganizationQueryService
{
    Task<Organization?> GetOrganizationByIdAsync(Guid organizationId);
    Task<IEnumerable<Organization>> GetAllOrganizationsAsync();
}
