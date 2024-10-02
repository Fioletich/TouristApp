using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Featureds.Queries.GetAllFeatereds;

public class GetAllFeaturedsRequestHandler : IRequestHandler<GetAllFeateredsRequest, IEnumerable<Featured>> {
    private readonly ITouristApplicationDbContext _context;

    public GetAllFeaturedsRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task<IEnumerable<Featured>> Handle(GetAllFeateredsRequest request, CancellationToken cancellationToken) {
        return await _context.Featureds.ToListAsync(cancellationToken);
    }
}