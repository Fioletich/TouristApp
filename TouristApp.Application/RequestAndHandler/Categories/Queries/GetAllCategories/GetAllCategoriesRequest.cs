using MediatR;
using TouristApp.Domain.Models;
using TouristApp.Domain.Models.Category;

namespace TouristApp.Application.RequestAndHandler.Categories.Queries.GetAllCategories;

public record GetAllCategoriesRequest : IRequest<IEnumerable<Category>>;