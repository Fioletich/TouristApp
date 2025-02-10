using MediatR;

namespace TouristApp.Application.RequestAndHandler.RoutesCategories.Commands.CreateRouteCategory;

public record CreateRouteCategoryRequest(Guid RouteId, Guid CategoryOfRouteId) : IRequest;