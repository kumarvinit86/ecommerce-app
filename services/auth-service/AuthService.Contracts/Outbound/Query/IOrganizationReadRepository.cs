using AuthService.Domain.Entities;

namespace AuthService.Contracts.Outbound.Query;

public interface IOrganizationReadRepository
{
    Task<IEnumerable<Organization>> GetAllAsync();
    Task<Organization?> GetByIdAsync(Guid organizationId);
}
