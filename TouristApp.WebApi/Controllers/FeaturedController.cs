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
public class FeaturedController(IMediator mediator) : ControllerBase {
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Featured>>> GetAll() {
        return Ok(await mediator.Send(new GetAllFeateredsRequest()));
    }

    [HttpGet]
    public async Task<ActionResult<Featured>> Get([FromQuery] GetFeaturedRequest request) {
        return Ok(await mediator.Send(request));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromQuery] CreateFeaturedRequest request) {
         return Ok(await mediator.Send(request));
    }

    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] DeleteFeaturedRequest request) {
        await mediator.Send(request);

        return Ok();
    }
}