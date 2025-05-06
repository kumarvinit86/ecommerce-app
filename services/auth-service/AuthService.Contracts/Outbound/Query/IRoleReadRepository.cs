using AuthService.Domain.Entities;

namespace AuthService.Contracts.Outbound.Query
{
    public interface IRoleReadRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<List<Role>> GetByIdAsync(Guid userId);
        Task<bool> RoleExistsAsync(string roleName);
    }
}
