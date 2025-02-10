using MediatR;

namespace TouristApp.Application.RequestAndHandler.PinpointsCategories.Commands.DeletePinpointCategory;

public record DeletePinpointCategoryRequest(Guid PinpointId, Guid CategoryOfPinpointId) : IRequest;