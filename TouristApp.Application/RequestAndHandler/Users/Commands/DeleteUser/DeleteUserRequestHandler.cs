using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Users.Commands.DeleteUser;

public class DeleteUserRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<DeleteUserRequest> {
    public async Task Handle(DeleteUserRequest request, CancellationToken cancellationToken) {
        var entity = await context.Users
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (entity is null || entity.Id != request.UserId)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        context.Users.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
    }
}