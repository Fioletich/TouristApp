using MediatR;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.PinpointCategory;

namespace TouristApp.Application.RequestAndHandler.PinpointsCategories.Commands.CreatePinpointCategory;

public class CreatePinpointCategoryRequestHandler(ITouristApplicationDbContext context) 
    : IRequestHandler<CreatePinpointCategoryRequest> {

    public async Task Handle(CreatePinpointCategoryRequest request, CancellationToken cancellationToken) {
        var pinpointCategory = PinpointCategory.Create(request.CategoryOfPinpointId, request.PinpointId);
        
        pinpointCategory.Update();
        
        await context.PinpointCategories.AddAsync(pinpointCategory, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}