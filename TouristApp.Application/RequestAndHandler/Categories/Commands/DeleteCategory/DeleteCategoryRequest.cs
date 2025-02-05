using MediatR;
using TouristApp.Domain.Models.Category;

namespace TouristApp.Application.RequestAndHandler.Categories.Commands.DeleteCategory;

public record DeleteCategoryRequest(Guid Id) : IRequest;