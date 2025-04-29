using AuthService.API.DTOs;
using AuthService.Contracts.Inbound.Command;
using AuthService.Contracts.Inbound.Query;
using CommunityToolkit.Diagnostics;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserCommandService userCommandService;
    private readonly IUserQueryService userQueryService;

    public UserController(IUserCommandService userCommandService, IUserQueryService userQueryService)
    {
        Guard.IsNotNull(userCommandService, nameof(userCommandService));
        this.userCommandService = userCommandService;
        Guard.IsNotNull(userQueryService, nameof(userQueryService));
        this.userQueryService = userQueryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto dto)
    {
        var userId = await userCommandService.CreateUserAsync(dto.FullName, dto.Email, dto.Password);
        return CreatedAtAction(nameof(GetUser), new { id = userId }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, UpdateUserDto dto)
    {
        await userCommandService.UpdateUserAsync(id, dto.FullName, dto.Email);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DisableUser(Guid id)
    {
        await userCommandService.DisableUserAsync(id);
        return NoContent();
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var user = await userQueryService.GetProfileAsync(id); 
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
}
