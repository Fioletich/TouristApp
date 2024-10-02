using MediatR;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.Users.Commands.DeleteUser;
using TouristApp.Application.Users.Commands.UpdateUserRequest;
using TouristApp.Application.Users.Commands.UserCreate;
using TouristApp.Application.Users.Queries.GetAllUsers;
using TouristApp.Application.Users.Queries.GetUser;
using TouristApp.Domain.Models;

namespace TouristApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase {
    private IMediator _mediator;

    public UserController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAll() {
        var list = await _mediator.Send(new GetAllUsersRequest());

        return Ok(list);
    }

    [HttpGet]
    public async Task<ActionResult<User>> Get([FromQuery] GetUserRequest request) {
        return Ok(await _mediator.Send(request));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromQuery] CreateUserRequest request) {
        return Ok(await _mediator.Send(request));
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromQuery] UpdateUserRequest request) {
        await _mediator.Send(request);

        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] DeleteUserRequest request) {
        await _mediator.Send(request);

        return Ok();
    }
}