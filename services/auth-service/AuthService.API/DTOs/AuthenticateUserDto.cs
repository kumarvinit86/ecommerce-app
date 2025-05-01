using Swashbuckle.AspNetCore.Annotations;

namespace AuthService.API.DTOs
{
    public class AuthenticateUserDto
    {
        [SwaggerSchema("The email address of the user.")]
        public string Email { get; set; }

        [SwaggerSchema("The user password.")]
        public string Password { get; set; }
    }

}
