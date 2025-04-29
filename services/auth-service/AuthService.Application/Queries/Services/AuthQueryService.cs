using AuthService.Contracts.Inbound.Query;
using AuthService.Contracts.Outbound.Query;
using CommunityToolkit.Diagnostics;
using MediatR;

namespace AuthService.Application.Queries.Services
{
    public class AuthQueryService : IAuthQueryService
    {
        private readonly ITokenReadService tokenReadService;

        public AuthQueryService(ITokenReadService tokenReadService)
        {
            Guard.IsNotNull(tokenReadService, nameof(tokenReadService));
            this.tokenReadService = tokenReadService ?? throw new ArgumentNullException(nameof(tokenReadService));
        }

        public Task<string> LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<string> RefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ValidateToken(string token)
        {
            return await tokenReadService.ValidateToken(token);
        }
    }
}
