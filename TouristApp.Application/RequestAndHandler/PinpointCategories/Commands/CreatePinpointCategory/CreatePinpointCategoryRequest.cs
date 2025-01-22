using MediatR;

namespace TouristApp.Application.RequestAndHandler.PinpointCategories.Commands.CreatePinpointCategory;

public class CreatePinpointCategoryRequest : IRequest<Guid> {
    public Guid CategoryId { get; set; }
    public Guid PinpointId { get; set; }
}