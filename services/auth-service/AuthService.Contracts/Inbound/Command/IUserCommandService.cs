
using AuthService.Domain.Entities;

namespace AuthService.Contracts.Inbound.Command;

public interface IUserCommandService
{
    Task<Guid> CreateUserAsync(string fullName, string email, string password);
    Task DisableUserAsync(Guid id);
    Task<User> GetUserByIdAsync(Guid id);
    Task UpdateUserAsync(Guid id, string fullName, string email);
}
