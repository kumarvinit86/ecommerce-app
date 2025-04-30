namespace AuthService.Contracts.Outbound.Query
{
    public interface ITokenReadService
    {
        Task<bool> ValidateToken(string token);
    }
}
