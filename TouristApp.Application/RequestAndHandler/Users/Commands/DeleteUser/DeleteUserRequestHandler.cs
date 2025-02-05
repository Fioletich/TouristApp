using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.User;

namespace TouristApp.Application.RequestAndHandler.Users.Commands.DeleteUser;

public class DeleteUserRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<DeleteUserRequest> {
    public async Task Handle(DeleteUserRequest request, CancellationToken cancellationToken) {
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user is null || user.Id != request.UserId)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        context.Users.Remove(user);
        await context.SaveChangesAsync(cancellationToken);
    }
}