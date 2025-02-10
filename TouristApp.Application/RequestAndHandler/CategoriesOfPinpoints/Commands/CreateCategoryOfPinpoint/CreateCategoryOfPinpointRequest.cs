using MediatR;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfPinpoints.Commands.CreateCategoryOfPinpoint;

public record CreateCategoryOfPinpointRequest(string Name, string Description) : IRequest<Guid>;