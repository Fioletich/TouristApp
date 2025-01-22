using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Users.Queries.GetUser;

public class GetUserRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<GetUserRequest, User> {
    public async Task<User> Handle(GetUserRequest request, CancellationToken cancellationToken) {
        var entity = await context.Users
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (entity is null || entity.Id != request.UserId)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        return entity;
    }
}