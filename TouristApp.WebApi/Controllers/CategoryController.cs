using MediatR;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.Categories.Commands.CreateCategory;
using TouristApp.Application.Categories.Commands.DeleteCategory;
using TouristApp.Application.Categories.Queries.GetAllCategories;
using TouristApp.Application.Categories.Queries.GetCategory;
using TouristApp.Domain.Models;

namespace TouristApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CategoryController(IMediator mediator) : ControllerBase {
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetAll() {
        return Ok(await mediator.Send(new GetAllCategoriesRequest()));
    }

    [HttpGet]
    public async Task<ActionResult<Category>> Get([FromQuery] GetCategoryRequest request) {
        return Ok(await mediator.Send(request));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromQuery] CreateCategoryRequest request) {
        return Ok(await mediator.Send(request));
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] DeleteCategoryRequest request) {
        await mediator.Send(request);

        return Ok();
    }
}