using AuthService.API.DTOs;
using FluentValidation;

namespace AuthService.API.Validators
{
    public class AssignRoleDtoValidator : AbstractValidator<AssignRoleDto>
    {
        public AssignRoleDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID is required.");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Role ID is required.");
        }
    }
}
