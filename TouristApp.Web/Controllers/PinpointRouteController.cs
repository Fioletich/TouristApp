﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.RequestAndHandler.PinpointRoutes.Commands.CreatePinpointRoute;
using TouristApp.Application.RequestAndHandler.PinpointRoutes.Commands.DeletePinpointRoute;
using TouristApp.Application.RequestAndHandler.PinpointRoutes.Queries.GetAllPinpointRoutes;
using TouristApp.Application.RequestAndHandler.PinpointRoutes.Queries.GetPinpointRoute;
using TouristApp.Domain.Models.PinpointRoute;

namespace TouristApp.Web.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class PinpointRouteController(IMediator mediator, IMapper mapper) : ControllerBase {
    [HttpPost]
    public async Task<ActionResult> Post([FromQuery] CreatePinpointRouteRequest request) {
        await mediator.Send(request);

        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> Remove([FromQuery] DeletePinpointRouteRequest request) {
        await mediator.Send(request);
        
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<PinpointRouteDto>> Get(GetPinpointRouteRequest request) {
        return mapper.Map<PinpointRouteDto>(await mediator.Send(request));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PinpointRouteDto>>> GetAll() {
        return Ok((await mediator.Send(new GetAllPinpointRoutesRequest()))
            .Select(mapper.Map<PinpointRouteDto>));
    }
}