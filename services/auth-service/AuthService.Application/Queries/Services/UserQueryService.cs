using AuthService.Contracts.Inbound.Query;
using AuthService.Contracts.Outbound.Query;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.Repositories.Query;
using CommunityToolkit.Diagnostics;

namespace AuthService.Application.Queries.Services
{
    public class UserQueryService : IUserQueryService
    {
        private readonly IUserReadRepository userReadRepository;

        public UserQueryService(IUserReadRepository userReadRepository)
        {
            Guard.IsNotNull(userReadRepository, nameof(userReadRepository));
            this.userReadRepository = userReadRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await userReadRepository.GetAllAsync();
        }

        public async Task<User?> GetProfileAsync(Guid userId)
        {
            return await userReadRepository.GetByIdAsync(userId);
        }
    }
}
