using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Featureds.Commands.CreateFeatured;

public class CreateFeaturedRequestHandler : IRequestHandler<CreateFeaturedRequest, Guid> {
    private readonly ITouristApplicationDbContext _context;

    public CreateFeaturedRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }
    
    public async Task<Guid> Handle(CreateFeaturedRequest request, CancellationToken cancellationToken) {
        var entity = new Featured()
        {
            Id = Guid.NewGuid(),
            TouristRouteId = request.TouristRouteId,
            UserId = request.UserId
        };

        await _context.Featureds.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}