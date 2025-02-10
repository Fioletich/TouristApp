using MediatR;
using TouristApp.Domain.Models.RouteCategory;

namespace TouristApp.Application.RequestAndHandler.RoutesCategories.Queries.GetAllRouteCategories;

public record GetAllRouteCategoriesRequest : IRequest<IEnumerable<RouteCategory>>;