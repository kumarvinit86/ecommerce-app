namespace AuthService.Contracts.Outbound.Command;

public interface ITokenWriteService
{
    string GenerateAccessToken(Guid userId, List<string> roles);
    string GenerateRefreshToken();
}
