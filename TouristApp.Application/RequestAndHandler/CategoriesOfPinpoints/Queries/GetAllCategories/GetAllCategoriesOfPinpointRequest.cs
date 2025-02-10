using MediatR;
using TouristApp.Domain.Models.Category;
using TouristApp.Domain.Models.CategoryOfPinpoint;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfPinpoints.Queries.GetAllCategories;

public record GetAllCategoriesOfPinpointRequest : IRequest<IEnumerable<CategoryOfPinpoint>>;