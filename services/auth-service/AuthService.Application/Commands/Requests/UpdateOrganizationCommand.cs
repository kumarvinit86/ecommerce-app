using MediatR;

namespace AuthService.Application.Commands.Requests
{
    internal class UpdateOrganizationCommand : IRequest<object>
    {
        public Guid OrganizationId { get; set; }
        public string NewName { get; set; }
    }
}