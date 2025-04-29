using AuthService.API.DTOs;
using AuthService.API.Validators;
using AuthService.Application.Commands.Services;
using AuthService.Application.Commands.Validators;
using AuthService.Application.Queries.Services;
using AuthService.Contracts.Inbound.Command;
using AuthService.Contracts.Inbound.Query;
using AuthService.Contracts.Outbound.Command;
using AuthService.Contracts.Outbound.Query;
using AuthService.Infrastructure.Repositories.Command;
using AuthService.Infrastructure.Repositories.Query;
using FluentValidation;

namespace AuthService.API
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Command Repositories
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IOrganizationWriteRepository, OrganizationWriteRepository>();
            services.AddScoped<IRoleWriteRepository, RoleWriteRepository>();
            services.AddScoped<ITokenWriteService, TokenWriteService>();

            // Query Repositories
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IOrganizationReadRepository, OrganizationReadRepository>();
            services.AddScoped<IRoleReadRepository, RoleReadRepository>();
            services.AddScoped<ITokenReadService, TokenReadService>();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register Application Services here without Validators (Validators will be handled in the API layer)
            //services.AddScoped<IUserCommandService, IUserCommandService>();
            //services.AddScoped<IUserQueryService, UserQueryService>();

            //services.AddScoped<IOrganizationCommandService, OrganizationCommandService>();
            //services.AddScoped<IOrganizationQueryService, OrganizationQueryService>();

            //services.AddScoped<IRoleCommandService, RoleCommandService>();
            //services.AddScoped<IRoleQueryService, RoleQueryService>();
            services.AddScoped<IOrganizationCommandService, OrganizationCommandService>();
            services.AddScoped<IUserCommandService, UserCommandService>();
            services.AddScoped<IRoleCommandService, RoleCommandService>();
            services.AddScoped<IAuthCommandService, AuthCommandService>();
            services.AddScoped<IUserQueryService, UserQueryService>();
            services.AddScoped<IRoleQueryService, RoleQueryService>();
            services.AddScoped<IAuthQueryService, AuthQueryService>();
            services.AddScoped<IOrganizationQueryService, OrganizationQueryService>();


            return services;
        }
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            // Register DTO Validators
            services.AddScoped<IValidator<CreateUserDto>, CreateUserDtoValidator>();
            services.AddScoped<IValidator<UpdateUserDto>, UpdateUserDtoValidator>();
            services.AddScoped<IValidator<CreateOrganizationDto>, CreateOrganizationDtoValidator>();
            services.AddScoped<IValidator<UpdateOrganizationDto>, UpdateOrganizationDtoValidator>();
            services.AddScoped<IValidator<AssignRoleDto>, AssignRoleDtoValidator>();
            services.AddScoped<IValidator<RemoveRoleDto>, RemoveRoleDtoValidator>();

            return services;
        }
    }

}
