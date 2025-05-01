using AuthService.API.DTOs;
using AuthService.API.Models;
using AuthService.Contracts.Inbound.Query;
using CommunityToolkit.Diagnostics;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth/[action]")]
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

    /// <summary>
    /// Authenticates a user using their email and password, and generates an access token and refresh token.
    /// </summary>
    /// <param name="dto">The DTO containing the user's email and password.</param>
    /// <returns>
    /// Returns a 200 OK response with the authentication tokens if successful,
    /// a 401 Unauthorized response if authentication fails, or
    /// a 400 Bad Request response in case of a server error.
    /// </returns>
    [HttpPost("authenticate")]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Authenticate(AuthenticateUserDto dto)
    {
        AuthResponse authResponse = new();
        try
        {
            var result = (await authQueryService.LoginAsync(dto.Email, dto.Password)).ToTuple();
            authResponse.AccessToken = result.Item1;
            authResponse.RefreshToken = result.Item2;
            authResponse.IsAuthenticated = true;
            return Ok(new { authResponse });
        }
        catch (UnauthorizedAccessException ex)
        {
            authResponse.IsAuthenticated = false;
            logger.LogError(ex, "Unauthorized access attempt. Email: {Email}", dto.Email);
            return Unauthorized(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            authResponse.IsAuthenticated = false;
            logger.LogError(ex, "Unauthorized access attempt. Email: {Email}", dto.Email);
            return BadRequest(new { Message = "Server Error." });
        }
    }

    /// <summary>
    /// Validates the provided token to check if it is valid and not expired.
    /// </summary>
    /// <param name="dto">The DTO containing the token to validate.</param>
    /// <returns>
    /// Returns a 200 OK response if the token is valid, or
    /// a 401 Unauthorized response if the token is invalid or expired.
    /// </returns>
    [HttpPost("validate-token")]
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
