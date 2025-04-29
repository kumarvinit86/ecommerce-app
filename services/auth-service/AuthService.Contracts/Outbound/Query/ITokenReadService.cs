using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Contracts.Outbound.Query
{
    public interface ITokenReadService
    {
        Task<bool> ValidateToken(string token);
    }
}
