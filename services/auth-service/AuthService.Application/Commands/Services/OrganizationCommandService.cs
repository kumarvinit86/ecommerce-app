using AuthService.Application.Commands.Requests;
using AuthService.Contracts.Inbound.Command;
using MediatR;
using CommunityToolkit.Diagnostics;

namespace AuthService.Application.Commands.Services
{
    public class OrganizationCommandService : IOrganizationCommandService
    {
        private readonly IMediator mediator;

        public OrganizationCommandService(IMediator mediator)
        {
            Guard.IsNotNull(mediator, nameof(mediator));
            this.mediator = mediator;
        }

        // Create Organization
        public async Task<Guid> CreateOrganizationAsync(string organizationName, Guid ownerId)
        {
            var command = new CreateOrganizationCommand
            {
                OrganizationName = organizationName,
                OwnerId = ownerId
            };

            return await mediator.Send(command);
        }

        // Update Organization
        public async Task UpdateOrganizationAsync(Guid organizationId, string newName)
        {
            var command = new UpdateOrganizationCommand
            {
                OrganizationId = organizationId,
                NewName = newName
            };

            await mediator.Send(command);
        }

        // Disable Organization
        public async Task DisableOrganizationAsync(Guid organizationId)
        {
            var command = new DisableOrganizationCommand
            {
                OrganizationId = organizationId
            };

            await mediator.Send(command);
        }
    }
}
