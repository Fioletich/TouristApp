using MediatR;

namespace TouristApp.Application.Categories.Commands.DeleteCategory;

public class DeleteCategoryRequest : IRequest {
    public Guid Id { get; set; }
}