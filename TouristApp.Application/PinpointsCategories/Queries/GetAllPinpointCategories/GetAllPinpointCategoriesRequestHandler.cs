using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.PinpointsCategories.Queries.GetAllPinpointCategories;

public class GetAllPinpointCategoriesRequestHandler(ITouristApplicationDbContext context) :
    IRequestHandler<GetAllPinpointCategoriesRequest, IEnumerable<PinpointCategory>> {
    private readonly ITouristApplicationDbContext _context = context;

    public async Task<IEnumerable<PinpointCategory>> Handle(GetAllPinpointCategoriesRequest request, CancellationToken cancellationToken) {
        return await _context.PinpointCategories.ToListAsync(cancellationToken);
    }
}