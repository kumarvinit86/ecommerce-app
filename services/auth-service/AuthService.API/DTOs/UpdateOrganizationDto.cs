namespace AuthService.API.DTOs
{
    public class UpdateOrganizationDto
    {
        public Guid OrganizationId { get; set; }
        public string? NewName { get; set; }
    }
}
