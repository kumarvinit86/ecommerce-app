namespace AuthService.API.DTOs
{
    public class CreateOrganizationDto
    {
        public string OrganizationName { get; set; }
        public Guid OwnerId { get; set; }
    }
}
