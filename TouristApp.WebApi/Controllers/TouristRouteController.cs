using MediatR;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.TouristRoutes.Commands.CreateTouristRoute;
using TouristApp.Application.TouristRoutes.Commands.DeleteTouristRoute;
using TouristApp.Application.TouristRoutes.Commands.UpdateTouristRoute;
using TouristApp.Application.TouristRoutes.Queries.GetAllTouristRoutes;
using TouristApp.Application.TouristRoutes.Queries.GetTouristRoute;
using TouristApp.Domain.Models;

namespace TouristApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TouristRouteController(IMediator mediator) : ControllerBase {
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TouristRoute>>> GetAll() {
        return Ok(await mediator.Send(new GetAllTouristRoutesRequest()));
    }

    [HttpGet]
    public async Task<ActionResult<TouristRoute>> Get([FromQuery] GetTouristRouteRequest request) {
        return Ok(await mediator.Send(request));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromQuery] CreateTouristRouteRequest request) {
        return Ok(await mediator.Send(request));
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromQuery] UpdateTouristRouteRequest request) {
        await mediator.Send(request);

        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] DeleteTouristRouteRequest request) {
        await mediator.Send(request);

        return Ok();
    }
}