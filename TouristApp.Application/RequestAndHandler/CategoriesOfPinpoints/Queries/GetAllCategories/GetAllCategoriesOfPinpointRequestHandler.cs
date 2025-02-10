using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.Category;
using TouristApp.Domain.Models.CategoryOfPinpoint;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfPinpoints.Queries.GetAllCategories;

public class GetAllCategoriesOfPinpointRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<GetAllCategoriesOfPinpointRequest, IEnumerable<CategoryOfPinpoint>> {

    public async Task<IEnumerable<CategoryOfPinpoint>> Handle(GetAllCategoriesOfPinpointRequest request, CancellationToken cancellationToken) {
        return await context.CategoriesOfPinpoints.ToListAsync(cancellationToken);
    }
}