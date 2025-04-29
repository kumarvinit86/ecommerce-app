using AuthService.Domain.Entities;

namespace AuthService.Contracts.Outbound.Query
{
    public interface IRoleReadRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetByIdAsync(Guid userId);
        Task<bool> RoleExistsAsync(string roleName);
    }
}
