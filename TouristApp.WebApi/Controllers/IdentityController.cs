using MediatR;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.RequestAndHandler.Users.Queries.GetUserByLogin;
using TouristApp.WebApi.Identity;

namespace TouristApp.WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class IdentityController(TokenGenerator tokenGenerator, IMediator mediator) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<string>> Login(string login, string password) {
        var user = await mediator.Send(new GetUserByLoginRequest(login));

        if (user.Password != password)
        {
            return Unauthorized();
        }
        
        return Ok(tokenGenerator.GenerateToken(user));
    } 
}