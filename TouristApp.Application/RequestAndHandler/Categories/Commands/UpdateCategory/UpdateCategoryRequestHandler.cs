using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.Category;

namespace TouristApp.Application.RequestAndHandler.Categories.Commands.UpdateCategory;

public class UpdateCategoryRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<UpdateCategoryRequest> {
    public async Task Handle(UpdateCategoryRequest request, CancellationToken cancellationToken) {
        var category = await context
            .Categories.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (category is null || request.Id != category.Id)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }

        category.Name = request.Name ?? category.Name;
        category.Description = request.Description ?? category.Description;
        category.Update();

        await context.SaveChangesAsync(cancellationToken);
    }
}