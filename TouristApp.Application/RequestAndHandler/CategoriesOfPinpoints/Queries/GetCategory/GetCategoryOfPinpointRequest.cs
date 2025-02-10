using MediatR;
using TouristApp.Domain.Models.Category;
using TouristApp.Domain.Models.CategoryOfPinpoint;

namespace TouristApp.Application.RequestAndHandler.CategoriesOfPinpoints.Queries.GetCategory;

public record GetCategoryOfPinpointRequest(Guid Id) : IRequest<CategoryOfPinpoint>;