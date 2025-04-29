using AuthService.Application.Commands.Requests;
using AuthService.Contracts.Inbound.Command;
using CommunityToolkit.Diagnostics;
using MediatR;

namespace AuthService.Application.Commands.Services
{
    public class RoleCommandService : IRoleCommandService
    {
        private readonly IMediator mediator;

        public RoleCommandService(IMediator mediator)
        {
            Guard.IsNotNull(mediator, nameof(mediator));
            this.mediator = mediator;
        }


        public async Task AssignRoleAsync(Guid userId, Guid roleId)
        {
            var command = new AssignRoleCommand
            {
                UserId = userId,
                RoleId = roleId
            };

            await mediator.Send(command);
        }


        public async Task RemoveRoleAsync(Guid userId, Guid roleId)
        {
            var command = new RemoveRoleCommand
            {
                UserId = userId,
                RoleId = roleId
            };

            await mediator.Send(command);
        }
    }
}
