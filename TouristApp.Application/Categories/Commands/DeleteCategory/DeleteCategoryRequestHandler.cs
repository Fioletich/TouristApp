using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Categories.Commands.DeleteCategory;

public class DeleteCategoryRequestHandler : IRequestHandler<DeleteCategoryRequest> {
    private readonly ITouristApplicationDbContext _context;
    
    public DeleteCategoryRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task Handle(DeleteCategoryRequest request, CancellationToken cancellationToken) {
        var entity = await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (entity is null && entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }

        _context.Categories.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}