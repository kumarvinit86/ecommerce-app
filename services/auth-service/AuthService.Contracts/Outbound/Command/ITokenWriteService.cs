using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Contracts.Outbound.Command
{
    public interface ITokenWriteService
    {
        string GenerateAccessToken(Guid userId, List<string> roles);
        string GenerateRefreshToken();
    }
}
