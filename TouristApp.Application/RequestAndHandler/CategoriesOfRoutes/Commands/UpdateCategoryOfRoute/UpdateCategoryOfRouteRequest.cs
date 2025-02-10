using MediatR;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Commands.UpdateCategoryOfRoute;

public record UpdateCategoryOfRouteRequest(Guid Id, string? Name, string? Description) : IRequest;