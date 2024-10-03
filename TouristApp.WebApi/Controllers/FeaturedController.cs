using MediatR;
using Microsoft.AspNetCore.Mvc;
using TouristApp.Application.Featureds.Commands.CreateFeatured;
using TouristApp.Application.Featureds.Commands.DeleteFeatured;
using TouristApp.Application.Featureds.Queries.GetAllFeatereds;
using TouristApp.Application.Featureds.Queries.GetFeatured;
using TouristApp.Domain.Models;

namespace TouristApp.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class FeaturedController : ControllerBase {
    private readonly IMediator _mediator;

    public FeaturedController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Featured>>> GetAll() {
        return Ok(await _mediator.Send(new GetAllFeateredsRequest()));
    }

    [HttpGet]
    public async Task<ActionResult<Featured>> Get([FromQuery] GetFeaturedRequest request) {
        return Ok(await _mediator.Send(request));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromQuery] CreateFeaturedRequest request) {
         return Ok(await _mediator.Send(request));
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] DeleteFeaturedRequest request) {
        await _mediator.Send(request);

        return Ok();
    }
}