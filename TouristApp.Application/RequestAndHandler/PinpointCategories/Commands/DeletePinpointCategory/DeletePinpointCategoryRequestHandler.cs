using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.PinpointCategories.Commands.DeletePinpointCategory;

public class DeletePinpointCategoryRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<DeletePinpointCategoryRequest> {
    private readonly ITouristApplicationDbContext _context = context;

    public async Task Handle(DeletePinpointCategoryRequest request, CancellationToken cancellationToken) {
        var entity = await _context.PinpointCategories
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (entity is null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(PinpointCategory), request.Id);
        }

        _context.PinpointCategories.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}