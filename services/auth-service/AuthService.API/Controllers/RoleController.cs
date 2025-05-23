﻿using AuthService.API.DTOs;
using AuthService.Contracts.Inbound.Command;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/roles/[action]")]
public class RoleController : ControllerBase
{
    private readonly IRoleCommandService roleCommandService;

    public RoleController(IRoleCommandService roleCommandService)
    {
        this.roleCommandService = roleCommandService;
    }

    [HttpPost(Name = "assign")]
    public async Task<IActionResult> AssignRole(AssignRoleDto dto)
    {
        await roleCommandService.AssignRoleAsync(dto.UserId, dto.RoleId);
        return NoContent();
    }

    [HttpPost(Name = "remove")]
    public async Task<IActionResult> RemoveRole(RemoveRoleDto dto)
    {
        await roleCommandService.RemoveRoleAsync(dto.UserId, dto.RoleId);
        return NoContent();
    }
}
