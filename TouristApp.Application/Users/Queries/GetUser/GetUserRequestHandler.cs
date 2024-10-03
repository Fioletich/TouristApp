using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Users.Queries.GetUser;

public class GetUserRequestHandler : IRequestHandler<GetUserRequest, User> {
    private readonly ITouristApplicationDbContext _context;

    public GetUserRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task<User> Handle(GetUserRequest request, CancellationToken cancellationToken) {
        var entity = await _context.Users
            .FirstOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);

        if (entity is null || entity.UserId != request.UserId)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        return entity;
    }
}