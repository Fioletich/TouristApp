using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.PinpointsCategories.Commands.CreatePinpointCategory;
using TouristApp.Application.PinpointsCategories.Commands.DeletePinpointCategory;
using TouristApp.Application.PinpointsCategories.Queries.GetAllPinpointCategories;
using TouristApp.Application.PinpointsCategories.Queries.GetPinpointCategory;
using TouristApp.Domain.Models;

namespace TouristApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class PinpointCategoryController(IMediator mediator) : ControllerBase {
    private readonly IMediator _mediator = mediator;
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PinpointCategory>>> GetAll() {
        return Ok(await _mediator.Send(new GetAllPinpointCategoriesRequest()));
    }

    [HttpGet]
    public async Task<ActionResult<PinpointCategory>> Get([FromQuery] GetPinpointCategoryRequest request) {
        return Ok(await _mediator.Send(request));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromQuery] CreatePinpointCategoryRequest request) {
        return Ok(await _mediator.Send(request));
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] DeletePinpointCategoryRequest request) {
        await _mediator.Send(request);

        return Ok();
    }
}