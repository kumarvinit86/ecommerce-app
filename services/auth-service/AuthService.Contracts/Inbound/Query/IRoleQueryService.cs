using AuthService.Domain.Entities;

namespace AuthService.Contracts.Inbound.Query;

public interface IRoleQueryService
{
    Task<List<string>> GetUserRolesAsync(Guid userId);
    Task<IEnumerable<Role>> GetAllRolesAsync();
}
