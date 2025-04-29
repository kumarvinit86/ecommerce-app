using MediatR;

namespace AuthService.Application.Commands.Requests
{
    internal class CreateOrganizationCommand : IRequest<Guid>
    {
        public string OrganizationName { get; set; }
        public Guid OwnerId { get; set; }
    }
}