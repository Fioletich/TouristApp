using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.CategoryOfRoute;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Queries.GetAllCategoriesOfRoutes;

public class GetAllCategopriesOfRoutesRequestHandler(ITouristApplicationDbContext context) 
    : IRequestHandler<GetAllCategoriesOfRoutes, IEnumerable<CategoryOfRoute>> {

    public async Task<IEnumerable<CategoryOfRoute>> Handle(GetAllCategoriesOfRoutes request, CancellationToken cancellationToken) {
        return await context.CategoriesOfRoutes.ToListAsync(cancellationToken);
    }
}