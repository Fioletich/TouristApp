using MediatR;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.RequestAndHandler.Routes.Commands.CreateRoute;
using TouristApp.Application.RequestAndHandler.Routes.Commands.DeleteRoute;
using TouristApp.Application.RequestAndHandler.Routes.Commands.UpdateRoute;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetAllRoutes;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoute;

namespace TouristApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class RouteController(IMediator mediator) : ControllerBase {
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Domain.Models.Route>>> GetAll() {
        var list = await mediator.Send(new GetAllRoutesRequest());
        
        return Ok(list);
    }

    [HttpGet]
    public async Task<ActionResult<Domain.Models.Route>> Get([FromQuery] GetRouteRequest request) {
        return Ok(await mediator.Send(request));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromQuery] CreateRouteRequest request) {
        return Ok(await mediator.Send(request));
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromQuery] UpdateRouteRequest request) {
        await mediator.Send(request);

        return Ok();
    }
    
    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] DeleteRouteRequest request) {
        await mediator.Send(request);

        return Ok();
    }
}