using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.PinpointCategory;

namespace TouristApp.Application.RequestAndHandler.PinpointsCategories.Queries.GetAllPinpointCategories;

public class GetAllPinpointCategoriesRequestHandler(ITouristApplicationDbContext context) 
    : IRequestHandler<GetAllPinpointCategoriesRequest, IEnumerable<PinpointCategory>>{

    public async Task<IEnumerable<PinpointCategory>> Handle(GetAllPinpointCategoriesRequest request, CancellationToken cancellationToken) {
        return await context.PinpointCategories.ToListAsync(cancellationToken);
    }
}