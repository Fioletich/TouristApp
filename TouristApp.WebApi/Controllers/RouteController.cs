using MediatR;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.Routes.Queries.GetAllRoutes;

namespace TouristApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class RouteController : ControllerBase {
    private readonly IMediator _mediator;

    public RouteController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Route>> GetAll() {
        var list = await _mediator.Send(new GetAllRoutesRequest());
        
        return Ok(list);
    }
}