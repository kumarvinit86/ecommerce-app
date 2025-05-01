using AuthService.Contracts.Inbound.Query;
using AuthService.Contracts.Outbound.Command;
using AuthService.Contracts.Outbound.Query;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.Helpers;
using CommunityToolkit.Diagnostics;
using MediatR;

namespace AuthService.Application.Queries.Services
{
    public class AuthQueryService : IAuthQueryService
    {
        private readonly ITokenReadService tokenReadService;
        private readonly ITokenWriteService tokenWriteService;
        private readonly IUserReadRepository userReadRepository;
        private readonly IRoleQueryService roleQueryService;
        public AuthQueryService(ITokenReadService tokenReadService, 
            IUserReadRepository userReadRepository,
            IRoleQueryService roleQueryService,
            ITokenWriteService tokenWriteService)
        {
            Guard.IsNotNull(tokenReadService, nameof(tokenReadService));
            this.tokenReadService = tokenReadService;

            Guard.IsNotNull(userReadRepository, nameof(userReadRepository));
            this.userReadRepository = userReadRepository;

            Guard.IsNotNull(roleQueryService, nameof(roleQueryService));
            this.roleQueryService = roleQueryService;

            Guard.IsNotNull(tokenWriteService, nameof(tokenWriteService));
            this.tokenWriteService = tokenWriteService;
        }

        public async Task<(string AccessToken, string RefreshToken)> LoginAsync(string email, string password)
        {
            // Validating user  
            var user = await userReadRepository.GetByEmailAsync(email);
            if (user is null)
            {
                throw new UnauthorizedAccessException("Invalid emailid");
            }

            var isValidUser = user.PasswordHash == Crypto.HashPassword(password);
            if (!isValidUser)
            {
                throw new UnauthorizedAccessException("Invalid password");
            }

            // Get Roles of user  
            List<string> roles = await roleQueryService.GetUserRolesAsync(user.Id);
            
            // Generate token  
            var accessToken = tokenWriteService.GenerateAccessToken(user.Id, roles);
            var refreshToken = tokenWriteService.GenerateRefreshToken();
            return (accessToken, refreshToken);
        }

        public async Task<string> RefreshTokenAsync(string refreshToken)
        {
            // Validate the provided refresh token
            var isValidRefreshToken = await tokenReadService.ValidateToken(refreshToken);
            if (!isValidRefreshToken)
            {
                throw new UnauthorizedAccessException("Invalid refresh token");
            }

            // Retrieve the user associated with the refresh token
            //var user = await userReadRepository.GetAllAsync()
            //    .ContinueWith(task => task.Result.FirstOrDefault(u =>
            //        u.RefreshTokens.Any(rt => rt.Token == refreshToken && rt.ExpiryDate > DateTime.UtcNow)));

            //Will be replaced with the above code after adding Tables for user and token 
            var user =new User();

            if (user is null)
            {
                throw new UnauthorizedAccessException("Refresh token is not associated with any user or has expired");
            }

            // Get roles of the user
            var roles = await roleQueryService.GetUserRolesAsync(user.Id);

            // Generate a new access token
            var newAccessToken = tokenWriteService.GenerateAccessToken(user.Id, roles);

            return newAccessToken;
        }

        public async Task<bool> ValidateToken(string token)
        {
            return await tokenReadService.ValidateToken(token);
        }
    }
}
