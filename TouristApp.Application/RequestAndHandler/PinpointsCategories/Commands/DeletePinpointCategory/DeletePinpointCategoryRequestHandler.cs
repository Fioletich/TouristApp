using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Application.RequestAndHandler.PinpointsCategories.Queries.GetPinpointCategory;

namespace TouristApp.Application.RequestAndHandler.PinpointsCategories.Commands.DeletePinpointCategory;

public class DeletePinpointCategoryRequestHandler(ITouristApplicationDbContext context, IMediator mediator) 
    : IRequestHandler<DeletePinpointCategoryRequest> {

    public async Task Handle(DeletePinpointCategoryRequest request, CancellationToken cancellationToken) {
        var pinpointCategory = await mediator
            .Send(new GetPinpointCategoryRequest(request.PinpointId, 
                request.CategoryOfPinpointId), cancellationToken);
        
        context.PinpointCategories.Remove(pinpointCategory);
        await context.SaveChangesAsync(cancellationToken);
    }
}