using AuthService.Application.Commands.Requests;
using AuthService.Contracts.Inbound.Command;
using AuthService.Domain.Entities;
using CommunityToolkit.Diagnostics;
using MediatR;

namespace AuthService.Application.Commands.Services
{
    public class UserCommandService : IUserCommandService
    {
        private readonly IMediator mediator;

        public UserCommandService(IMediator mediator)
        {
            Guard.IsNotNull(mediator, nameof(mediator));
            this.mediator = mediator;
        }

        public async Task<Guid> CreateUserAsync(string fullName, string email, string password)
        {
            var command = new CreateUserCommand
            {
                FullName = fullName,
                Email = email,
                Password = password
            };

            return await mediator.Send(command);
        }

        public async Task UpdateUserAsync(Guid userId, string fullName, string email)
        {
            var command = new UpdateUserCommand
            {
                UserId = userId,
                FullName = fullName,
                Email = email
            };

            await mediator.Send(command);
        }

        public async Task DisableUserAsync(Guid userId)
        {
            var command = new DisableUserCommand
            {
                UserId = userId
            };

            await mediator.Send(command);
        }

        public Task<User> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
