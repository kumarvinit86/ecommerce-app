using AuthService.API.DTOs;
using AuthService.API.Models;
using AuthService.Contracts.Inbound.Query;
using CommunityToolkit.Diagnostics;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthQueryService authQueryService;
    private readonly ILogger<AuthController> logger;

    public AuthController(IAuthQueryService authQueryService, ILogger<AuthController> logger)
    {
        Guard.IsNotNull(authQueryService, nameof(authQueryService));
        Guard.IsNotNull(logger, nameof(logger));
        this.authQueryService = authQueryService;
        this.logger = logger;
    }

    // Authenticate user and generate token
    [HttpPost(Name = "authenticate")]
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
            logger.LogError(ex, "Unauthorized access attempt. Email: {Email}", dto.Email);
            return Unauthorized(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unauthorized access attempt. Email: {Email}", dto.Email);
            return BadRequest(new { Message = "Server Error." });
        }
    }

    // Validate token
    [HttpPost(Name = "validate-token")]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
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
