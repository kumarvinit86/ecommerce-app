using MediatR;

namespace AuthService.Application.Commands.Requests
{
    internal class RemoveRoleCommand : IRequest<object>
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}