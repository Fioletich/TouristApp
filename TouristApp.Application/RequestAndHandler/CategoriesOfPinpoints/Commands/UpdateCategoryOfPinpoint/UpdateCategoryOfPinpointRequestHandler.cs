using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.Category;
using TouristApp.Domain.Models.CategoryOfPinpoint;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfPinpoints.Commands.UpdateCategoryOfPinpoint;

public class UpdateCategoryOfPinpointRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<UpdateCategoryOfPinpointRequest> {
    public async Task Handle(UpdateCategoryOfPinpointRequest request, CancellationToken cancellationToken) {
        var category = await context
            .CategoriesOfPinpoints.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (category is null || request.Id != category.Id)
        {
            throw new NotFoundException(nameof(CategoryOfPinpoint), request.Id);
        }

        category.Name = request.Name ?? category.Name;
        category.Description = request.Description ?? category.Description;
        category.Update();

        await context.SaveChangesAsync(cancellationToken);
    }
}