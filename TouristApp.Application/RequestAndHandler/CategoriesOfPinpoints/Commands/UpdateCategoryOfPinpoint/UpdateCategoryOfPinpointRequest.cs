using MediatR;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfPinpoints.Commands.UpdateCategoryOfPinpoint;

public record UpdateCategoryOfPinpointRequest(Guid Id, string? Name, string? Description) : IRequest;