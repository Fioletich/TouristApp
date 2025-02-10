using MediatR;
using TouristApp.Domain.Models.CategoryOfRoute;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfRoutes.Queries.GetAllCategoriesOfRoutes;

public record GetAllCategoriesOfRoutes() : IRequest<IEnumerable<CategoryOfRoute>>;