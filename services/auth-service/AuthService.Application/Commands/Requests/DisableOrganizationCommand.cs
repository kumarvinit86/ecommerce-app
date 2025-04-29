using MediatR;

namespace AuthService.Application.Commands.Requests
{
    internal class DisableOrganizationCommand : IRequest<object>
    {
        public Guid OrganizationId { get; set; }
    }
}