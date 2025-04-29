using AuthService.API.DTOs;
using FluentValidation;

namespace AuthService.API.Validators
{
    public class RemoveRoleDtoValidator : AbstractValidator<RemoveRoleDto>
    {
        public RemoveRoleDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID is required.");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Role ID is required.");
        }
    }
}
