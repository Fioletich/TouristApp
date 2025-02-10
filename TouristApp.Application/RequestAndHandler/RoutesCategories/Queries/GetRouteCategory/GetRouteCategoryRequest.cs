using MediatR;
using TouristApp.Domain.Models.RouteCategory;

namespace TouristApp.Application.RequestAndHandler.RoutesCategories.Queries.GetRouteCategory;

public record GetRouteCategoryRequest(Guid RouteId, Guid CategoryOfRouteId) : IRequest<RouteCategory>;