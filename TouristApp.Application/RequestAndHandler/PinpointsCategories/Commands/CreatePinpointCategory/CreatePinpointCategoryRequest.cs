using MediatR;

namespace TouristApp.Application.RequestAndHandler.PinpointsCategories.Commands.CreatePinpointCategory;

public record CreatePinpointCategoryRequest(Guid PinpointId, Guid CategoryOfPinpointId) : IRequest;