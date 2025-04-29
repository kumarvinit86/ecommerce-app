using AuthService.Contracts.Outbound.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Infrastructure.Repositories.Command
{
    public class TokenWriteService : ITokenWriteService
    {
        public string GenerateAccessToken(Guid userId, List<string> roles)
        {
            // Implement the logic to generate JWT Token for access
            return "generated_access_token";
        }

        public string GenerateRefreshToken()
        {
            // Implement logic for generating refresh token
            return "generated_refresh_token";
        }
    }
}
