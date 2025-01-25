using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Application.RequestAndHandler.Roles.Queries.GetRole;

namespace TouristApp.Application.RequestAndHandler.Roles.Commands.DeleteRole;

public class DeleteRoleRequestHandler(ITouristApplicationDbContext context, IMediator mediator) 
    : IRequestHandler<DeleteRoleRequest> {

    public async Task Handle(DeleteRoleRequest request, CancellationToken cancellationToken) {
        var role = await mediator.Send(new GetRoleRequest(request.Id), cancellationToken);

        context.Roles.Remove(role);
        
        await context.SaveChangesAsync(cancellationToken);
    }
}