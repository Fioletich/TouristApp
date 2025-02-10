using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.Category;
using TouristApp.Domain.Models.CategoryOfPinpoint;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfPinpoints.Queries.GetCategory;

public class GetCategoryOfPinpointRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<GetCategoryOfPinpointRequest, CategoryOfPinpoint> {

    public async Task<CategoryOfPinpoint> Handle(GetCategoryOfPinpointRequest request, CancellationToken cancellationToken) {
        var category = await context.CategoriesOfPinpoints
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (category is null || category.Id != request.Id)
        {
            throw new NotFoundException(nameof(CategoryOfPinpoint), request.Id);
        }

        return category;
    }
}