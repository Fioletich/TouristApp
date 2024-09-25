using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.TouristRoutes.Commands.CreateTouristRoute;

public class CreateTouristRouteRequestHandler : IRequestHandler<CreateTouristRouteRequest, Guid> {
    private ITouristApplicationDbContext _context;

    public CreateTouristRouteRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task<Guid> Handle(CreateTouristRouteRequest request, CancellationToken cancellationToken) {
        var entity = new TouristRoute()
        {
            Id = Guid.NewGuid(),
            PinPointId = request.PinPointId,
            RouteId = request.RouteId
        };

        await _context.TouristRoutes.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}