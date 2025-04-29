using AuthService.Application.Commands.Requests;
using AuthService.Contracts.Inbound.Command;
using CommunityToolkit.Diagnostics;
using MediatR;

namespace AuthService.Application.Commands.Services
{
    public class AuthCommandService : IAuthCommandService
    {
        private readonly IMediator mediator;

        public AuthCommandService(IMediator mediator)
        {
            Guard.IsNotNull(mediator, nameof(mediator));
            this.mediator = mediator;
        }

        public Task<bool> AuthenticateAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateTokenAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
