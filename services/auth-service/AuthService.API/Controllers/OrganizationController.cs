using AuthService.API.DTOs;
using AuthService.Contracts.Inbound.Command;
using AuthService.Contracts.Inbound.Query;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/organizations/[action]")]
public class OrganizationController : ControllerBase
{
    private readonly IOrganizationCommandService organizationCommandService;
    private readonly IOrganizationQueryService organizationQueryService;

    public OrganizationController(IOrganizationCommandService organizationCommandService, IOrganizationQueryService organizationQueryService)
    {
        this.organizationCommandService = organizationCommandService;
        this.organizationQueryService = organizationQueryService;
    }

    [HttpPost(Name = "create-organization")]
    public async Task<IActionResult> CreateOrganization(CreateOrganizationDto dto)
    {
        var organizationId = await organizationCommandService.CreateOrganizationAsync(dto.OrganizationName, dto.OwnerId);
        return CreatedAtAction(nameof(GetOrganization), new { id = organizationId }, null);
    }

    [HttpPost(Name = "update-organization")]
    public async Task<IActionResult> UpdateOrganization(Guid id, UpdateOrganizationDto dto)
    {
        await organizationCommandService.UpdateOrganizationAsync(id, dto.NewName);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DisableOrganization(Guid id)
    {
        await organizationCommandService.DisableOrganizationAsync(id);
        return NoContent();
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrganization(Guid id)
    {
        // Assuming a method exists in the service to fetch organization details
        var organization = await organizationQueryService.GetOrganizationByIdAsync(id);
        if (organization == null)
        {
            return NotFound();
        }
        return Ok(organization);
    }
}
