namespace AuthService.API.DTOs
{
    public class UpdateUserDto
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
