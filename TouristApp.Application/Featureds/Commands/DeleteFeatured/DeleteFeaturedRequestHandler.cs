using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Featureds.Commands.DeleteFeatured;

public class DeleteFeaturedRequestHandler : IRequestHandler<DeleteFeaturedRequest> {
    private readonly ITouristApplicationDbContext _context;

    public DeleteFeaturedRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task Handle(DeleteFeaturedRequest request, CancellationToken cancellationToken) {
        var entity = await _context.Featureds
            .FirstOrDefaultAsync(f => f.Id == request.Id);

        if (entity is null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(Featured), request.Id);
        }

        _context.Featureds.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}