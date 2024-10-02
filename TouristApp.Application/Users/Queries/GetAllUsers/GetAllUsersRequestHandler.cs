using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Users.Queries.GetAllUsers;

public class GetAllUsersRequestHandler : IRequestHandler<GetAllUsersRequest, IEnumerable<User>> {
    private readonly ITouristApplicationDbContext _context;

    public GetAllUsersRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task<IEnumerable<User>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken) {
        return await _context.Users.ToListAsync(cancellationToken);
    }
}