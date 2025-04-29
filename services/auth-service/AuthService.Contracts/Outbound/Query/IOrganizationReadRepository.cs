using AuthService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Contracts.Outbound.Query
{
    public interface IOrganizationReadRepository
    {
        Task<IEnumerable<Organization>> GetAllAsync();
        Task<Organization?> GetByIdAsync(Guid organizationId);
    }
}
