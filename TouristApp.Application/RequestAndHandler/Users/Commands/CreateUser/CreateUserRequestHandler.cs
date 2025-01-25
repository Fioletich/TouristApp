using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.Role;
using TouristApp.Domain.Models.User;

namespace TouristApp.Application.RequestAndHandler.Users.Commands.CreateUser;

public class CreateUserRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<CreateUserRequest, Guid> {
    public async Task<Guid> Handle(CreateUserRequest request, CancellationToken cancellationToken) {
        var role = await context.Roles.FirstOrDefaultAsync(r => r.Id == request.RoleId, cancellationToken);

        if (role is null || role.Id != request.RoleId)
        {
            throw new NotFoundException(typeof(Role).ToString(), request.RoleId);
        }
        
        var user = User.Create(role, request.Login, request.Password, request.City);

        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}