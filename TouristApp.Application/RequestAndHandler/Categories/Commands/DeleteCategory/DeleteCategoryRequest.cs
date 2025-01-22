using MediatR;

namespace TouristApp.Application.RequestAndHandler.Categories.Commands.DeleteCategory;

public class DeleteCategoryRequest : IRequest {
    public Guid Id { get; set; }
}