using MediatR;
using TouristApp.Domain.Models.CategoryOfRoute;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Queries.GetCategoryOfRoute;

public record GetCategoryOfRouteRequest(Guid Id) : IRequest<CategoryOfRoute>;