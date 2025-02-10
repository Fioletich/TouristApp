using MediatR;
using TouristApp.Domain.Models.PinpointCategory;

namespace TouristApp.Application.RequestAndHandler.PinpointsCategories.Queries.GetPinpointCategory;

public record GetPinpointCategoryRequest(Guid PinpointId, Guid CategoryOfPinpointId) : IRequest<PinpointCategory>;