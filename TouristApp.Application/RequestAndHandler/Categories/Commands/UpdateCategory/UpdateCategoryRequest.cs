using MediatR;
using TouristApp.Domain.Models.Category;

namespace TouristApp.Application.RequestAndHandler.Categories.Commands.UpdateCategory;

public record UpdateCategoryRequest(Guid Id, string? Name, string? Description) : IRequest;