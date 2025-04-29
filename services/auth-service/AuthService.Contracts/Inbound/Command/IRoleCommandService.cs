namespace AuthService.Contracts.Inbound.Command;

public interface IRoleCommandService
{
    Task AssignRoleAsync(Guid userId, Guid RoleId);
    Task RemoveRoleAsync(Guid userId, Guid RoleId);
}
