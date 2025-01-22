using MediatR;

namespace TouristApp.Application.RequestAndHandler.Categories.Commands.UpdateCategory;

public class UpdateCategoryRequest : IRequest {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}