using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Featureds.Queries.GetFeatured;

public class GetFeaturedRequestHandler : IRequestHandler<GetFeaturedRequest, Featured> {
    private readonly ITouristApplicationDbContext _context;

    public GetFeaturedRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task<Featured> Handle(GetFeaturedRequest request, CancellationToken cancellationToken) {
        var entity = await _context.Featureds
            .FirstOrDefaultAsync(f => f.UserId == request.Id, cancellationToken);

        if (entity is null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(Featured), request.Id);
        }

        return entity;
    }
}