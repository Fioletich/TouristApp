using MediatR;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.RequestAndHandler.Users.Commands.CreateUser;
using TouristApp.Application.RequestAndHandler.Users.Commands.DeleteUser;
using TouristApp.Application.RequestAndHandler.Users.Commands.UpdateUserRequest;
using TouristApp.Application.RequestAndHandler.Users.Queries.GetAllUsers;
using TouristApp.Application.RequestAndHandler.Users.Queries.GetUser;
using TouristApp.Domain.Models;

namespace TouristApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController(IMediator mediator) : ControllerBase {
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAll() {
        var list = await mediator.Send(new GetAllUsersRequest());

        return Ok(list);
    }

    [HttpGet]
    public async Task<ActionResult<User>> Get([FromQuery] GetUserRequest request) {
        return Ok(await mediator.Send(request));
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
    public async Task<ActionResult> Delete([FromQuery] DeleteUserRequest request) {
        await mediator.Send(request);

        return Ok();
    }
}