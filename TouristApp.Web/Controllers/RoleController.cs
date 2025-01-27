using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.RequestAndHandler.Roles.Commands.CreateRole;
using TouristApp.Application.RequestAndHandler.Roles.Commands.DeleteRole;
using TouristApp.Application.RequestAndHandler.Roles.Queries.GetAllRoles;
using TouristApp.Application.RequestAndHandler.Roles.Queries.GetRole;
using TouristApp.Domain.Models.Role;

namespace TouristApp.Web.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class RoleController(IMediator mediator, IMapper mapper) : ControllerBase {
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleDTO>>> GetAll() {
        var roles = (await mediator.Send(new GetAllRolesRequest()))
            .Select(mapper.Map<RoleDTO>);
        
        return Ok(roles);
    }
    
    [HttpGet]
    public async Task<ActionResult<RoleDTO>> Get([FromQuery] Guid id) {
        return Ok(mapper.Map<RoleDTO>(await mediator.Send(new GetRoleRequest(id))));
    }
    
    [HttpDelete]
    public async Task<ActionResult> Remove([FromQuery] Guid id) {
        await mediator.Send(new DeleteRoleRequest(id));

        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromQuery] CreateRoleRequest role) {
        return Ok(await mediator.Send(new CreateRoleRequest(role.Name)));
    }
}