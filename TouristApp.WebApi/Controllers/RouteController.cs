using MediatR;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.Routes.Commands.CreateRoute;
using TouristApp.Application.Routes.Commands.DeleteRoute;
using TouristApp.Application.Routes.Commands.UpdateRoute;
using TouristApp.Application.Routes.Queries.GetAllRoutes;
using TouristApp.Application.Routes.Queries.GetRoute;

namespace TouristApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class RouteController : ControllerBase {
    private readonly IMediator _mediator;

    public RouteController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Domain.Models.Route>>> GetAll() {
        var list = await _mediator.Send(new GetAllRoutesRequest());
        
        return Ok(list);
    }

    [HttpGet]
    public async Task<ActionResult<Domain.Models.Route>> Get([FromQuery] GetRouteRequest request) {
        return Ok(await _mediator.Send(request));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromQuery] CreateRouteRequest request) {
        return Ok(await _mediator.Send(request));
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromQuery] UpdateRouteRequest request) {
        await _mediator.Send(request);

        return Ok();
    }
    
    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] DeleteRouteRequest request) {
        await _mediator.Send(request);

        return Ok();
    }
}