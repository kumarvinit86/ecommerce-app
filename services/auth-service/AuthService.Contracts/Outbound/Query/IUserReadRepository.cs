using AuthService.Domain.Entities;

namespace AuthService.Contracts.Outbound.Query;

public interface IUserReadRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(Guid userId);
    Task<List<string>> GetRolesAsync(Guid userId);
}
