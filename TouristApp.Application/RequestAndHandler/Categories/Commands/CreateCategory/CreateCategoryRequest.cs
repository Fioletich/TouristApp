using MediatR;

namespace TouristApp.Application.RequestAndHandler.Categories.Commands.CreateCategory;

public record CreateCategoryRequest(string Name, string Description) : IRequest<Guid>;