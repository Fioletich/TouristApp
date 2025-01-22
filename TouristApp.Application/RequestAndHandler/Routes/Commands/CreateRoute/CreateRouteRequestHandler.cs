using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Routes.Commands.CreateRoute;

public class CreateRouteRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<CreateRouteRequest, Guid> {
    public async Task<Guid> Handle(CreateRouteRequest request, CancellationToken cancellationToken) {
        var entity = new Route()
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            Name = request.Name
        };

        await context.Routes.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}