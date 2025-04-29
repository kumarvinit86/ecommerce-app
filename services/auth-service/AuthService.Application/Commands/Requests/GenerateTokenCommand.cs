using MediatR;

namespace AuthService.Application.Commands.Requests
{
    internal class GenerateTokenCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
    }
}