using AuthService.API.DTOs;
using AuthService.API.Models;
using AuthService.Contracts.Inbound.Command;
using AuthService.Contracts.Inbound.Query;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthQueryService authQueryService;

    public AuthController(IAuthCommandService authCommandService, IAuthQueryService authQueryService)
    {
        this.authQueryService = authQueryService;
    }

    // Authenticate user and generate token
    [HttpPost("authenticate")]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Authenticate(AuthenticateUserDto dto)
    {
        try
        {
            AuthResponse authResponse = new();
            var result = (await authQueryService.LoginAsync(dto.Email, dto.Password)).ToTuple();
            authResponse.AccessToken = result.Item1;
            authResponse.RefreshToken = result.Item2;
            authResponse.EmailId = dto.Email;
            return Ok(new { authResponse });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = "Server Error." });
        }
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
