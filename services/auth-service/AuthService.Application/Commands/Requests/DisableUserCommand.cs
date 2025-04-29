using MediatR;

namespace AuthService.Application.Commands.Requests
{
    internal class DisableUserCommand : IRequest<object>
    {
        public Guid UserId { get; set; }
    }
}