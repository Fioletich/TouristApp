using MediatR;

namespace TouristApp.Application.RequestAndHandler.RoutesCategories.Commands.DeleteRouteCategory;

public record DeleteRouteCategoryRequest(Guid RouteId, Guid RouteCategoryId) : IRequest;