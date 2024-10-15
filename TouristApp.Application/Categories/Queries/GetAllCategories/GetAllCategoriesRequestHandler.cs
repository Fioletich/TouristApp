using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Categories.Queries.GetAllCategories;

public class GetAllCategoriesRequestHandler : IRequestHandler<GetAllCategoriesRequest, IEnumerable<Category>> {
    private readonly ITouristApplicationDbContext _context;

    public GetAllCategoriesRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken) {
        return await _context.Categories.ToListAsync(cancellationToken);
    }
}