using AuthService.Contracts.Inbound.Query;
using AuthService.Contracts.Outbound.Query;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.Repositories.Query;
using CommunityToolkit.Diagnostics;

namespace AuthService.Application.Queries.Services
{
    public class RoleQueryService : IRoleQueryService
    {
        private readonly IRoleReadRepository roleReadRepository;

        public RoleQueryService(IRoleReadRepository roleReadRepository)
        {
            Guard.IsNotNull(roleReadRepository, nameof(roleReadRepository));
            this.roleReadRepository = roleReadRepository;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await roleReadRepository.GetAllAsync();
        }

        public async Task<List<string>> GetUserRolesAsync(Guid userId)
        {
            var role = await roleReadRepository.GetByIdAsync(userId);
            return role != null ? new List<string> { role.Name } : new List<string>();
        }
    }
}
