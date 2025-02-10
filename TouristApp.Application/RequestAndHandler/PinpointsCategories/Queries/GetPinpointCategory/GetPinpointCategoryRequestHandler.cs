using MediatR;
using Microsoft.EntityFrameworkCore;
using TouristApp.Application.Exceptions;
using TouristApp.Application.Interfaces;
using TouristApp.Domain.Models.PinpointCategory;

namespace TouristApp.Application.RequestAndHandler.PinpointsCategories.Queries.GetPinpointCategory;

public class GetPinpointCategoryRequestHandler(ITouristApplicationDbContext context, IMediator mediator)
    : IRequestHandler<GetPinpointCategoryRequest, PinpointCategory> {

    public async Task<PinpointCategory> Handle(GetPinpointCategoryRequest request, CancellationToken cancellationToken) {
        var pinpointCategory = await context.PinpointCategories
            .FirstOrDefaultAsync(pc => pc.PinpointId == request.PinpointId
                && pc.CategoryOfPinpointId == request.CategoryOfPinpointId, cancellationToken);

        if (pinpointCategory is null)
        {
            throw new NotFoundException(nameof(PinpointCategory), request.PinpointId);
        }
        
        return pinpointCategory;
    }
}