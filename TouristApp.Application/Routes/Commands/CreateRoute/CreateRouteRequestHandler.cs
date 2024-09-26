using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Routes.Commands.CreateRoute;

public class CreateRouteRequestHandler : IRequestHandler<CreateRouteRequest, Guid> {
    private readonly ITouristApplicationDbContext _context;

    public CreateRouteRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task<Guid> Handle(CreateRouteRequest request, CancellationToken cancellationToken) {
        var entity = new Route()
        {
            Id = Guid.NewGuid(),
            Description = request.Description,
            Name = request.Name
        };

        await _context.Routes.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}