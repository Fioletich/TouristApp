using MediatR;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Commands.CreateCategoryOfRoute;

public record CreateCategoryOfRouteRequest(string Name, string Description) : IRequest<Guid>;