using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.RequestAndHandler.Categories.Commands.CreateCategory;
using TouristApp.Application.RequestAndHandler.Categories.Commands.DeleteCategory;
using TouristApp.Application.RequestAndHandler.Categories.Commands.UpdateCategory;
using TouristApp.Application.RequestAndHandler.Categories.Queries.GetAllCategories;
using TouristApp.Application.RequestAndHandler.Categories.Queries.GetCategory;
using TouristApp.Domain.Models.Category;

namespace TouristApp.Web.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CategoryController(IMediator mediator, IMapper mapper) : ControllerBase {
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll() {
        var categories = (await mediator.Send(new GetAllCategoriesRequest()))
            .Select(mapper.Map<CategoryDTO>);
        
        return Ok(categories);
    }

    [HttpGet]
    public async Task<ActionResult<CategoryDTO>> Get([FromQuery] GetCategoryRequest request) {
        return Ok(mapper.Map<CategoryDTO>(await mediator.Send(request)));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromQuery] CreateCategoryRequest request) {
        return Ok(await mediator.Send(request));
    }

    [HttpDelete]
    public async Task<ActionResult> Remove([FromQuery] DeleteCategoryRequest request) {
        await mediator.Send(request);

        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromQuery] UpdateCategoryRequest request) {
        await mediator.Send(request);

        return Ok();
    }
}