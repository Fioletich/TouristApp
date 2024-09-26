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
public class TouristRouteController : ControllerBase {
    private readonly IMediator _mediator;

    public TouristRouteController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TouristRoute>>> GetAll() {
        return Ok(await _mediator.Send(new GetAllTouristRoutesRequest()));
    }

    [HttpGet]
    public async Task<ActionResult<TouristRoute>> Get([FromBody] GetTouristRouteRequest request) {
        return Ok(await _mediator.Send(request));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromBody] CreateTouristRouteRequest request) {
        return Ok(await _mediator.Send(request));
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UpdateTouristRouteRequest request) {
        await _mediator.Send(request);

        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromBody] DeleteTouristRouteRequest request) {
        await _mediator.Send(request);

        return Ok();
    }
}