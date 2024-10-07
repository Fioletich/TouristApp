using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Featureds.Commands.CreateFeatured;

public class CreateFeaturedRequestHandler : IRequestHandler<CreateFeaturedRequest, Guid> {
    private readonly ITouristApplicationDbContext _context;

    public CreateFeaturedRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }
    
    public async Task<Guid> Handle(CreateFeaturedRequest request, CancellationToken cancellationToken) {
        var touristRoute = await _context.TouristRoutes
            .FirstOrDefaultAsync(t => t.Id == request.TouristRouteId, cancellationToken);

        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (touristRoute is null || user is null || touristRoute.Id != request.TouristRouteId ||
            user.Id != request.UserId)
        {
            throw new ArgumentException("Tourist route or user was not found by id");
        }
        
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