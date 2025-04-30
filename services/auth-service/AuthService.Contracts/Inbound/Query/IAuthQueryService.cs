namespace AuthService.Contracts.Inbound.Query;

public interface IAuthQueryService
{
    Task<(string AccessToken, string RefreshToken)> LoginAsync(string email, string password);
    Task<string> RefreshTokenAsync(string refreshToken);
    Task<bool> ValidateToken(string token);
}
