using AuthService.API.DTOs;
using FluentValidation;

namespace AuthService.Application.Commands.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email is required and must be a valid email.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Full name is required.");
        }
    }
}
