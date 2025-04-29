using MediatR;

namespace AuthService.Application.Commands.Requests
{
    internal class RegisterUserCommand : IRequest<Task<string>>
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string OrganizationName { get; set; }
    }
}