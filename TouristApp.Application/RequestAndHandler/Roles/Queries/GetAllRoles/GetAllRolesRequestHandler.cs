using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.Role;

namespace TouristApp.Application.RequestAndHandler.Roles.Queries.GetAllRoles;

public class GetAllRolesRequestHandler(ITouristApplicationDbContext context)
    : IRequestHandler<GetAllRolesRequest, IEnumerable<Role>> {

    public async Task<IEnumerable<Role>> Handle(GetAllRolesRequest request, CancellationToken cancellationToken) {
        return await context.Roles.ToListAsync(cancellationToken);
    }
}