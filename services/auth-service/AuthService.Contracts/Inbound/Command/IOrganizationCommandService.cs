namespace AuthService.Contracts.Inbound.Command;

public interface IOrganizationCommandService
{
    Task<Guid> CreateOrganizationAsync(string organizationName, Guid ownerId);
    Task UpdateOrganizationAsync(Guid organizationId, string newName);
    Task DisableOrganizationAsync(Guid organizationId);
}
