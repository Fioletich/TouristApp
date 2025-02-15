using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.Role;

namespace TouristApp.Application.RequestAndHandler.Roles.Queries.GetRoleByName;

public class GetRoleByNameRequestHandler(ITouristApplicationDbContext context) 
    : IRequestHandler<GetRoleByNameRequest, Role> {

    public async Task<Role> Handle(GetRoleByNameRequest request, CancellationToken cancellationToken) {
        var role = await context.Roles
            .FirstOrDefaultAsync(r => r.Name == request.Name, cancellationToken);

        if (role is null)
        {
            throw new NotFoundException(nameof(Role), request.Name);
        }

        return role;
    }
}