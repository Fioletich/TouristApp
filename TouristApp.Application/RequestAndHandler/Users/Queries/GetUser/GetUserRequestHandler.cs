using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.User;

namespace TouristApp.Application.RequestAndHandler.Users.Queries.GetUser;

public class GetUserRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<GetUserRequest, User> {
    public async Task<User> Handle(GetUserRequest request, CancellationToken cancellationToken) {
        var user = await context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (user is null || user.Id != request.Id)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        return user;
    }
}