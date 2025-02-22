﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.RequestAndHandler.Routes.Commands.CreateRoute;
using TouristApp.Application.RequestAndHandler.Routes.Commands.DeleteRoute;
using TouristApp.Application.RequestAndHandler.Routes.Commands.UpdateRoute;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetAllRoutes;
using TouristApp.Application.RequestAndHandler.Routes.Queries.GetRoute;
using TouristApp.Domain.Models.Route;

namespace TouristApp.Web.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class RouteController(IMediator mediator, IMapper mapper) : ControllerBase {
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RouteDto>>> GetAll() {
        var list = (await mediator.Send(new GetAllRoutesRequest()))
            .Select(mapper.Map<RouteDto>);
        
        return Ok(list);
    }

    [HttpGet]
    public async Task<ActionResult<RouteDto>> Get([FromQuery] GetRouteRequest request) {
        return Ok(mapper.Map<RouteDto>(await mediator.Send(request)));
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
    public async Task<ActionResult> Remove([FromQuery] DeleteRouteRequest request) {
        await mediator.Send(request);

        return Ok();
    }
}