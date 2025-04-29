using MediatR;

namespace AuthService.Application.Commands.Requests
{
    internal class UpdateUserCommand : IRequest<object>
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}