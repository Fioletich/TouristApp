using MediatR;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Commands.CreateCategoryOfRoute;
using TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Commands.DeleteCategoryOfRoute;
using TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Commands.UpdateCategoryOfRoute;
using TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Queries.GetAllCategoriesOfRoutes;
using TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Queries.GetCategoryOfRoute;
using TouristApp.Domain.Models.CategoryOfRoute;

namespace TouristApp.Web.Controllers;


[Route("api/[controller]/[action]")]
[ApiController]
public class CategoryOfRouteController(IMediator mediator)
    : ControllerBase {
    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromQuery] CreateCategoryOfRouteRequest request) {
        return Ok(await mediator.Send(request));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryOfRoute>>> GetAll() {
        return Ok(await mediator.Send(new GetAllCategoriesOfRoutes()));
    }

    [HttpGet]
    public async Task<ActionResult<CategoryOfRoute>> Get([FromQuery] Guid id) {
        return Ok(await mediator.Send(new GetCategoryOfRouteRequest(id)));
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] Guid id) {
        await mediator.Send(new DeleteCategoryOfRouteRequest(id));
        
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromQuery] UpdateCategoryOfRouteRequest request) {
        await mediator.Send(request);

        return Ok();
    }
}