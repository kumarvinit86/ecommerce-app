﻿namespace AuthService.Domain.Entities;

public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public static implicit operator Role(string v)
    {
        throw new NotImplementedException();
    }
}
