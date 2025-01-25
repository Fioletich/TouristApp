using MediatR;
using TouristApp.Domain.Models.Category;

namespace TouristApp.Application.RequestAndHandler.Categories.Queries.GetCategory;

public record GetCategoryRequest(Guid Id) : IRequest<Category>;