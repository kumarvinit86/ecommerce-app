using AuthService.Contracts.Outbound.Command;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.SqlDataBase;

namespace AuthService.Infrastructure.Repositories.Command
{
    public class UserWriteRepository : IUserWriteRepository
    {
        private readonly AuthDbContext dbContext;

        public UserWriteRepository(AuthDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();
        }
    }

}
