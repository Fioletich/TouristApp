using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Categories.Commands.UpdateCategory;

public class UpdateCategoryRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<UpdateCategoryRequest> {
    private readonly ITouristApplicationDbContext _context = context;

    public async Task Handle(UpdateCategoryRequest request, CancellationToken cancellationToken) {
        var entity = await _context
            .Categories.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (entity is null || request.Id != entity.Id)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }

        entity.Name = request.Name;
        entity.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);
    }
}