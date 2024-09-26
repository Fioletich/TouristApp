using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.PinPoints.Commands.CreatePinPoint;

public class CreatePinPointRequestHandler : IRequestHandler<CreatePinPointRequest, Guid> {
    private readonly ITouristApplicationDbContext _context;

    public CreatePinPointRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePinPointRequest request, CancellationToken cancellationToken) {
        var entity = new PinPoint()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            XCoordinate = request.XCoordinate,
            YCoordinate = request.YCoordinate
        };

        await _context.PinPoints.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}