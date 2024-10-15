using MediatR;

namespace TouristApp.Application.Categories.Commands.CreateCategory;

public class CreateCategoryRequest : IRequest<Guid> {
    public string Name { get; set; }
    public string Description { get; set; }
}