using AuthService.API.DTOs;
using FluentValidation;

namespace AuthService.API.Validators
{
    public class CreateOrganizationDtoValidator : AbstractValidator<CreateOrganizationDto>
    {
        public CreateOrganizationDtoValidator()
        {
            RuleFor(x => x.OrganizationName).NotEmpty().WithMessage("Organization name is required.");
            RuleFor(x => x.OwnerId).NotEmpty().WithMessage("Owner ID is required.");
        }
    }
}
