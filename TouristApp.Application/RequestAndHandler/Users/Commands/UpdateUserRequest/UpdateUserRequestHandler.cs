using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;

namespace TouristApp.Application.RequestAndHandler.Users.Commands.UpdateUserRequest;

public class UpdateUserRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<RequestAndHandler.Users.Commands.UpdateUserRequest.UpdateUserRequest> {
    public async Task Handle(RequestAndHandler.Users.Commands.UpdateUserRequest.UpdateUserRequest request, CancellationToken cancellationToken) {
        var entity = await context.Users
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

        await context.SaveChangesAsync(cancellationToken);
    }
}