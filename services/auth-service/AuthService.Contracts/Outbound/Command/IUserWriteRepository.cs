using AuthService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Contracts.Outbound.Command
{
    public interface IUserWriteRepository
    {
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}
