using MediatR;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.PinPoints.Commands.CreatePinPoint;
using TouristApp.Application.PinPoints.Commands.DeletePinPoint;
using TouristApp.Application.PinPoints.Commands.UpdatePinPoint;
using TouristApp.Application.PinPoints.Queries.GetAllPinPoints;
using TouristApp.Application.PinPoints.Queries.GetPinPoint;
using TouristApp.Domain.Models;

namespace TouristApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class PinPointController : ControllerBase {
    private readonly IMediator _mediator;

    public PinPointController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PinPoint>>> GetAll() {
        return Ok(await _mediator.Send(new GetAllPinPointsRequest()));
    }

    [HttpGet]
    public async Task<ActionResult<PinPoint>> Get([FromBody] GetPinPointRequest request) {
        return Ok(await _mediator.Send(request));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromBody] CreatePinPointRequest request) {
        return Ok(await _mediator.Send(request));
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromBody] DeletePinPointRequest request) {
        await _mediator.Send(request);
            
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UpdatePinPointRequest request) {
        await _mediator.Send(request);

        return Ok();
    }
}