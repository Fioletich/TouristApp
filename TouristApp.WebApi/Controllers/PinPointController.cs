using MediatR;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.RequestAndHandler.Pinpoints.Commands.CreatePinpoint;
using TouristApp.Application.RequestAndHandler.Pinpoints.Commands.DeletePinpoint;
using TouristApp.Application.RequestAndHandler.Pinpoints.Commands.UpdatePinpoint;
using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetAllPinPoints;
using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetPinPoint;
using TouristApp.Domain.Models;

namespace TouristApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class PinPointController(IMediator mediator) : ControllerBase {
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pinpoint>>> GetAll() {
        return Ok(await mediator.Send(new GetAllPinpointsRequest()));
    }

    [HttpGet]
    public async Task<ActionResult<Pinpoint>> Get([FromQuery] GetPinpointRequest request) {
        return Ok(await mediator.Send(request));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromQuery] CreatePinpointRequest request) {
        return Ok(await mediator.Send(request));
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] DeletePinpointRequest request) {
        await mediator.Send(request);
            
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromQuery] UpdatePinpointRequest request) {
        await mediator.Send(request);

        return Ok();
    }
}