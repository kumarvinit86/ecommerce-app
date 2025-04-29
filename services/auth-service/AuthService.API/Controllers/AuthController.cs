using AuthService.API.DTOs;
using AuthService.Contracts.Inbound.Command;
using AuthService.Contracts.Inbound.Query;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthCommandService authCommandService;
    private readonly IAuthQueryService authQueryService;

    public AuthController(IAuthCommandService authCommandService, IAuthQueryService authQueryService)
    {
        this.authCommandService = authCommandService;
        this.authQueryService = authQueryService;
    }

    // Authenticate user and generate token
    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate(AuthenticateUserDto dto)
    {
        var isValidUser = await authCommandService.AuthenticateAsync(dto.Email, dto.Password);
        if (!isValidUser)
        {
            return Unauthorized(new { Message = "Invalid email or password." });
        }

        var token = await authCommandService.GenerateTokenAsync(dto.Email);
        return Ok(new { Token = token });
    }

    // Validate token
    [HttpPost("validate-token")]
    public async Task<IActionResult> ValidateToken(ValidateTokenDto dto)
    {
        var isValid = await authQueryService.ValidateToken(dto.Token);
        if (!isValid)
        {
            return Unauthorized(new { Message = "Invalid or expired token." });
        }

        return Ok(new { Message = "Token is valid." });
    }
}
