using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.Role;
using TouristApp.Domain.Models.User;

namespace TouristApp.Application.RequestAndHandler.Users.Commands.UpdateUserRequest;

public class UpdateUserRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<UpdateUserRequest> {
    public async Task Handle(UpdateUserRequest request, CancellationToken cancellationToken) {
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user is null || user.Id != request.UserId)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        if (request.RoleId is not null)
        {
            user.Role = await context.Roles.FirstOrDefaultAsync(r => r.Id == request.RoleId, cancellationToken) ?? 
                        throw new NotFoundException(nameof(Role), request.RoleId);
        }

        user.Login = request.Login ?? user.Login;
        user.Password = request.Password ?? user.Password;
        user.City = request.City ?? user.City;
        
        user.Update();

        await context.SaveChangesAsync(cancellationToken);
    }
}