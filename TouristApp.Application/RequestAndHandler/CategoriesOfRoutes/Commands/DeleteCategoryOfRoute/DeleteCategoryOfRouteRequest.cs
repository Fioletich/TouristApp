using MediatR;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Commands.DeleteCategoryOfRoute;

public record DeleteCategoryOfRouteRequest(Guid Id) : IRequest;