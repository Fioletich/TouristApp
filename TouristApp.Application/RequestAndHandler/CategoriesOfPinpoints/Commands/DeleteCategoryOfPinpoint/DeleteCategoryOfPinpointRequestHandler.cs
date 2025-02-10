using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.Category;
using TouristApp.Domain.Models.CategoryOfPinpoint;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfPinpoints.Commands.DeleteCategoryOfPinpoint;

public class DeleteCategoryOfPinpointRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<DeleteCategoryOfPinpointRequest> {
    public async Task Handle(DeleteCategoryOfPinpointRequest request, CancellationToken cancellationToken) {
        var category = await context.CategoriesOfPinpoints
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (category is null || category.Id != request.Id)
        {
            throw new NotFoundException(nameof(CategoryOfPinpoint), request.Id);
        }

        context.CategoriesOfPinpoints.Remove(category);
        await context.SaveChangesAsync(cancellationToken);
    }
}