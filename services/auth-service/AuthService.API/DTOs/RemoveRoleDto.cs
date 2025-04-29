namespace AuthService.API.DTOs
{
    public class RemoveRoleDto
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
