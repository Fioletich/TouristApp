using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.Users.Commands.UpdateUserRequest;

public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest> {
    private readonly ITouristApplicationDbContext _context;

    public UpdateUserRequestHandler(ITouristApplicationDbContext context) {
        _context = context;
    }

    public async Task Handle(UpdateUserRequest request, CancellationToken cancellationToken) {
        var entity = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (entity is null || entity.Id == request.UserId)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        entity.Login = request.Login;
        entity.Password = request.Password;
        entity.Bio = request.Bio;
        entity.PhoneNumber = request.PhoneNumber;
        entity.Country = request.Country;
        entity.City = request.City;

        await _context.SaveChangesAsync(cancellationToken);
    }
}