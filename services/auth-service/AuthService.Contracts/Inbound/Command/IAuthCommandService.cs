namespace AuthService.Contracts.Inbound.Command;

public interface IAuthCommandService
{
    Task<bool> AuthenticateAsync(string email, string password);
    Task<string> GenerateTokenAsync(string email);
}
