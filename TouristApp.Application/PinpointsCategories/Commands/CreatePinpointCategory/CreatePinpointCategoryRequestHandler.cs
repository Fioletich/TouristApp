using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.PinpointsCategories.Commands.CreatePinpointCategory;

public class CreatePinpointCategoryRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<CreatePinpointCategoryRequest, Guid> {
    private readonly ITouristApplicationDbContext _context = context;

    public async Task<Guid> Handle(CreatePinpointCategoryRequest request, CancellationToken cancellationToken) {
        var category = await _context.Categories
            .FirstOrDefaultAsync(c => request.CategoryId == c.Id, cancellationToken);

        var pinpoint = await _context.PinPoints
            .FirstOrDefaultAsync(p => p.Id == request.PinpointId, cancellationToken);

        if (category is null || category.Id != request.CategoryId)
        {
            throw new NotFoundException(nameof(Category), request.CategoryId);
        }

        if (pinpoint is null || pinpoint.Id != request.PinpointId)
        {
            throw new NotFoundException(nameof(PinPoint), request.PinpointId);
        }
        
        var categoryPinpoint = new PinpointCategory()
        {
            Id = Guid.NewGuid(),
            CategoryId = request.CategoryId,
            PinpointId = request.PinpointId
        };

        await _context.PinpointCategories.AddAsync(categoryPinpoint, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return categoryPinpoint.Id;
    }
}