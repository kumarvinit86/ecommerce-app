using AuthService.API.DTOs;
using Swashbuckle.AspNetCore.Filters;

namespace AuthService.API.SwaggerConfiguration.ModelSamples;

public class AuthenticateUserDtoExample : IExamplesProvider<AuthenticateUserDto>
{
    public AuthenticateUserDto GetExamples()
    {
        return new AuthenticateUserDto
        {
            Email = "superadmin@yourapp.com",
            Password = "Super@123"
        };
    }
}