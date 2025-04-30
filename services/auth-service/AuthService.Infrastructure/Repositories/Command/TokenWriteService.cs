using AuthService.Contracts.Outbound.Command;
using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Infrastructure.Repositories.Command;

public class TokenWriteService : ITokenWriteService
{
    private readonly IConfiguration configuration;
    public TokenWriteService(IConfiguration configuration)
    {
        Guard.IsNotNull(configuration, nameof(configuration));
        this.configuration = configuration;
    }
    public string GenerateAccessToken(Guid userId, List<string> roles)
    {
        var secret = configuration.GetValue<string>("SecretPrivateKey");
        Guard.IsNotNullOrEmpty(secret, nameof(secret));
        var issuer = configuration.GetValue<string>("Issuer");
        Guard.IsNotNullOrEmpty(issuer, nameof(issuer));
        var audience = configuration.GetValue<string>("Audience");
        Guard.IsNotNullOrEmpty(audience, nameof(audience));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
        }
        return Convert.ToBase64String(randomNumber);
    }
}
