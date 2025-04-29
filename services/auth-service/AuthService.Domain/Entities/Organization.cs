namespace AuthService.Domain.Entities;

public class Organization
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public Guid OwnerUserId { get; set; }
    public User OwnerUser { get; set; } = default!;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
