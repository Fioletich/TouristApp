using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.PinpointsCategories.Queries.GetPinpointCategory;

public class GetPinpointCategoryRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<GetPinpointCategoryRequest, PinpointCategory> {
    private readonly ITouristApplicationDbContext _context = context;

    public async Task<PinpointCategory> Handle(GetPinpointCategoryRequest request, CancellationToken cancellationToken) {
        var entity = await _context.PinpointCategories
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (entity is null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(PinpointCategory), request.Id);
        }

        return entity;
    }
}