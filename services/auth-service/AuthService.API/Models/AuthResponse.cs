namespace AuthService.API.Models
{
    public class AuthResponse
    {
        public bool IsAuthenticated { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
