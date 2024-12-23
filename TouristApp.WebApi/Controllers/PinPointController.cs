﻿using MediatR;
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
public class PinPointController(IMediator mediator) : ControllerBase {
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PinPoint>>> GetAll() {
        return Ok(await mediator.Send(new GetAllPinPointsRequest()));
    }

    [HttpGet]
    public async Task<ActionResult<PinPoint>> Get([FromQuery] GetPinPointRequest request) {
        return Ok(await mediator.Send(request));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromQuery] CreatePinPointRequest request) {
        return Ok(await mediator.Send(request));
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] DeletePinPointRequest request) {
        await mediator.Send(request);
            
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromQuery] UpdatePinPointRequest request) {
        await mediator.Send(request);

        return Ok();
    }
}