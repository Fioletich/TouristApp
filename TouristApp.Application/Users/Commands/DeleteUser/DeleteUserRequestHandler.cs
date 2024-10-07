using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Users.Commands.DeleteUser;

public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest> {
    private readonly ITouristApplicationDbContext _context;

    public DeleteUserRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task Handle(DeleteUserRequest request, CancellationToken cancellationToken) {
        var entity = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (entity is null || entity.Id != request.UserId)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        _context.Users.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}