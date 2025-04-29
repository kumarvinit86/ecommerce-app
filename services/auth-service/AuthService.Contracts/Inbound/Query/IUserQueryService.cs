using AuthService.Domain.Entities;

namespace AuthService.Contracts.Inbound.Query;

public interface IUserQueryService
{
    Task<User?> GetProfileAsync(Guid userId);
}
