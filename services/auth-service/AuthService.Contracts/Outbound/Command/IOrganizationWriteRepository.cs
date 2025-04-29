using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Contracts.Outbound.Command
{
    public interface IOrganizationWriteRepository
    {
        Task<Guid> CreateAsync(string organizationName, Guid ownerId);
        Task UpdateNameAsync(Guid organizationId, string newName);
        Task DisableAsync(Guid organizationId);
    }
}
