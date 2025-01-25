using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.Role;

namespace TouristApp.Application.RequestAndHandler.Roles.Queries.GetRole;

public class GetRoleRequestHandler(ITouristApplicationDbContext context) 
    : IRequestHandler<GetRoleRequest, Role> {

    public async Task<Role> Handle(GetRoleRequest request, CancellationToken cancellationToken) {
        var role = await context.Roles.FirstOrDefaultAsync(r => r.Id == request.Id);

        if (role is null || role.Id != request.Id)
        {
            throw new NotFoundException(typeof(Role).ToString(), request.Id);
        }
        
        return role;
    }
}