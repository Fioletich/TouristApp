using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.Role;

namespace TouristApp.Application.RequestAndHandler.Roles.Commands.CreateRole;

public class CreateRoleRequestHandler(ITouristApplicationDbContext context) : IRequestHandler<CreateRoleRequest, Guid>{

    public async Task<Guid> Handle(CreateRoleRequest request, CancellationToken cancellationToken) {
        var role = Role.Create(request.Name);
        
        await context.Roles.AddAsync(role, cancellationToken);
        
        await context.SaveChangesAsync(cancellationToken);
        
        return role.Id;
    }
}