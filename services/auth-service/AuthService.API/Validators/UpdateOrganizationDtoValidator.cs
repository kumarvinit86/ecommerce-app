using AuthService.API.DTOs;
using FluentValidation;

namespace AuthService.API.Validators
{
    public class UpdateOrganizationDtoValidator : AbstractValidator<UpdateOrganizationDto>
    {
        public UpdateOrganizationDtoValidator()
        {
            RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("Organization ID is required.");
            RuleFor(x => x.NewName).NotEmpty().WithMessage("New name is required.");
        }
    }
}
