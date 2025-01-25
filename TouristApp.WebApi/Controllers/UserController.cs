using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.RequestAndHandler.Users.Commands.CreateUser;
using TouristApp.Application.RequestAndHandler.Users.Commands.DeleteUser;
using TouristApp.Application.RequestAndHandler.Users.Commands.UpdateUserRequest;
using TouristApp.Application.RequestAndHandler.Users.Queries.GetAllUsers;
using TouristApp.Application.RequestAndHandler.Users.Queries.GetUser;
using TouristApp.Domain.Models.User;

namespace TouristApp.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]/[action]")]
public class UserController(IMediator mediator, IMapper mapper) : ControllerBase {
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll() {
        var list = (await mediator.Send(new GetAllUsersRequest()))
            .Select(mapper.Map<UserDTO>);

        return Ok(list);
    }

    [HttpGet]
    public async Task<ActionResult<UserDTO>> Get([FromQuery] GetUserRequest request) {
        return Ok(mapper.Map<UserDTO>(await mediator.Send(request)));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromQuery] CreateUserRequest request) {
        return Ok(await mediator.Send(request));
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromQuery] UpdateUserRequest request) {
        await mediator.Send(request);

        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> Remove([FromQuery] DeleteUserRequest request) {
        await mediator.Send(request);

        return Ok();
    }
}