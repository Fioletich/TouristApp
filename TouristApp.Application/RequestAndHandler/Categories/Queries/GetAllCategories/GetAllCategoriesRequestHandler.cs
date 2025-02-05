using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.Category;

namespace TouristApp.Application.RequestAndHandler.Categories.Queries.GetAllCategories;

public class GetAllCategoriesRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<GetAllCategoriesRequest, IEnumerable<Category>> {

    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken) {
        return await context.Categories.ToListAsync(cancellationToken);
    }
}