using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.RequestAndHandler.FavouriteRoutes.Commands.CreateFavouriteRoute;
using TouristApp.Application.RequestAndHandler.FavouriteRoutes.Commands.DeleteFavouriteRoute;
using TouristApp.Application.RequestAndHandler.FavouriteRoutes.Queries.GetAllFavouriteRoutes;
using TouristApp.Application.RequestAndHandler.FavouriteRoutes.Queries.GetFavouriteRoute;
using TouristApp.Domain.Models.FavouriteRoute;

namespace TouristApp.Web.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]  
public class FavouriteRouteController(IMediator mediator, IMapper mapper) : ControllerBase {
    [HttpGet]
    public async Task<ActionResult<FavouriteRouteDto>> Get([FromQuery] GetFavouriteRouteRequest request) {
        return Ok(mapper.Map<FavouriteRouteDto>(await mediator.Send(request)));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FavouriteRouteDto>>> GetAll() {
        var favouriteRoutes = (await mediator.Send(new GetAllFavouriteRouteRequest()))
            .Select(mapper.Map<FavouriteRouteDto>);
        
        return Ok(favouriteRoutes);
    }

    [HttpPost]
    public async Task<ActionResult<(Guid, Guid)>> Post([FromQuery] CreateFavouriteRouteRequest request) {
        return Ok(await mediator.Send(request));
    }

    [HttpDelete]
    public async Task<ActionResult> Remove([FromQuery] DeleteFavouriteRouteRequest request) {
        await mediator.Send(request);
        
        return Ok();
    }
}