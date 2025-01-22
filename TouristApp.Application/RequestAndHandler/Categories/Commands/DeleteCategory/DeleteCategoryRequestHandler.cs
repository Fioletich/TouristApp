using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Categories.Commands.DeleteCategory;

public class DeleteCategoryRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<DeleteCategoryRequest> {

    public async Task Handle(DeleteCategoryRequest request, CancellationToken cancellationToken) {
        var entity = await context.Categories
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (entity is null && entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }

        context.Categories.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
    }
}