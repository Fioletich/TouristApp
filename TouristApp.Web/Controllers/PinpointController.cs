using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.RequestAndHandler.Pinpoints.Commands.CreatePinpoint;
using TouristApp.Application.RequestAndHandler.Pinpoints.Commands.DeletePinpoint;
using TouristApp.Application.RequestAndHandler.Pinpoints.Commands.UpdatePinpoint;
using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetAllPinPoints;
using TouristApp.Application.RequestAndHandler.Pinpoints.Queries.GetPinPoint;
using TouristApp.Domain.Models.Pinpoint;

namespace TouristApp.Web.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class PinpointController(IMediator mediator, IMapper mapper) : ControllerBase {
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PinpointDTO>>> GetAll() {
        var pinpoints = (await mediator.Send(new GetAllPinpointsRequest()))
            .Select(mapper.Map<PinpointDTO>);
        
        return Ok(pinpoints);
    }

    [HttpGet]
    public async Task<ActionResult<PinpointDTO>> Get([FromQuery] GetPinpointRequest request) {
        return Ok(mapper.Map<PinpointDTO>(await mediator.Send(request)));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromQuery] CreatePinpointRequest request) {
        return Ok(await mediator.Send(request));
    }

    [HttpDelete]
    public async Task<ActionResult> Remove([FromQuery] DeletePinpointRequest request) {
        await mediator.Send(request);
            
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromQuery] UpdatePinpointRequest request) {
        await mediator.Send(request);

        return Ok();
    }
}