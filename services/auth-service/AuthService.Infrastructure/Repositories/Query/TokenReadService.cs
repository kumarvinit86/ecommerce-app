using AuthService.Contracts.Outbound.Query;

namespace AuthService.Infrastructure.Repositories.Query
{
    public class TokenReadService : ITokenReadService
    {
        public Task<bool> ValidateToken(string token)
        {
            // Implement token validation logic here
            return Task.FromResult(true); // Assume token is valid for now
        }
    }
}
